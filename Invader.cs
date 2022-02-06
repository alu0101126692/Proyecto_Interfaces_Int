using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

  public float health, speed, range, fireRatePerSec;
  public GameObject target, player, nexus, bullet, explosion;
  public bool shotReady = true;
  public float acceleration = 0f;
  public Vector3 noise;
  public float originalSpeed;
  public float bulletSeparation;

  public virtual void Start() {}

  public void parentStart() {
    player = GameObject.Find("Main Camera");
    nexus = GameObject.Find("Nexus");
    noise = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    acceleration = Random.Range(1f, 3f);
    originalSpeed = speed;
  }

  void Update() {
    // Select target.
    float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
    float distToNexus = Vector3.Distance(transform.position, nexus.transform.position);
    target = distToPlayer <= distToNexus ? player : nexus;
    
    //// Follow and try to attack target.
    // Not in shot range.
    speed += acceleration * Time.deltaTime;
    if (Vector3.Distance(transform.position, target.transform.position) > range) {
      transform.LookAt(target.transform.position + noise);
      transform.position += transform.forward * speed * Time.deltaTime;
    }
    // In shot range and shot ready
    else if (shotReady) {
      transform.LookAt(target.transform.position);
      speed = originalSpeed;
      shotReady = false;
      StartCoroutine(shoot());
    }
    // Not in shot range but shot not ready.
    else {
      transform.LookAt(target.transform.position);
    }

    // Check alive status.
    if (health <= 0) die();
  }

  void die() {
    Instantiate(explosion, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }

  IEnumerator shoot() {
    Vector3 position = transform.position;
    for (int i = 0; i < bulletSeparation; i++) position += transform.forward;
    Instantiate(bullet, position, transform.rotation);
    yield return new WaitForSeconds(1 / fireRatePerSec);
    shotReady = true;
  }

  // Detect shots.
  void OnCollisionEnter(Collision col) {
    if (col.collider.tag == "bullet") {
      health--;
    }
  }
}

