using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float speed = 50f;
  public float mapSize;
  public AudioSource audio;

  void Start() {
    mapSize = GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().mapSize;
  }

  void Update() {
    // Move forward.
    transform.position += transform.forward * speed * Time.deltaTime;
    
    // Destroy if out of map.
    if (Mathf.Abs(transform.position.x) > mapSize || Mathf.Abs(transform.position.y) > mapSize || Mathf.Abs(transform.position.z) > mapSize)
      Destroy(gameObject);
  }

  // If collides with anything thats not another bullet, gets destroyed.
  void OnCollisionEnter(Collision col) {
    if (col.collider.tag != "bullet") {
      audio.Play();
      Destroy(gameObject);
    }
  }

}
