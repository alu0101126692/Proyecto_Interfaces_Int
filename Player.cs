using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Player : MonoBehaviour {
  public float initialHealth = 50f;
  public float health = 50f;
  public int burstBulletScale;
  public GameObject bullet, healthBar;
  public int bursts = 1;
  public bool isShooting = false;
  public float fireRate = 5f;


  public bool shootButton;
  public AudioSource audio;


  


  void Start() {
    healthBar = GameObject.Find("HealthBar");
    healthBar.GetComponent<HealthBar>().setMaxHealth(health);

    // Initial weapon conditions.
    fireRate = 5;
    bursts = 1;
    burstBulletScale = 0;
  }

  
  void FixedUpdate() {
    
    if (shootButton && !isShooting) {
      isShooting = true;
      StartCoroutine(shoot());
    }
    if (health <= 0)
      GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().endGame();
  }
  

  public void shootInput(InputAction.CallbackContext value) {
    if (value.started) {
      shootButton = true;
    } else if (value.canceled) {
      shootButton = false;
    }
        
  }
  

  void shootBurst() {
    Vector3 mainBullet = transform.position + transform.forward - transform.up;
    Instantiate(bullet, mainBullet, transform.rotation);
    Vector3 right = mainBullet;
    Vector3 left = mainBullet;
    for (int i = 0; i < burstBulletScale; i++) {
      right += transform.right;
      left -= transform.right;
      Instantiate(bullet, right, transform.rotation);
      Instantiate(bullet, left, transform.rotation);
    }
  }

  IEnumerator shoot () {
    for (int i = 0; i < bursts; i++) {
      audio.Play();
      shootBurst();
      if (bursts != 1) yield return new WaitForSeconds(0.01f);
    }
    yield return new WaitForSeconds(1 / fireRate);
    isShooting = false;
  }

  public void addHealth(int newHealth) {
    health += newHealth;
    if (health > initialHealth) health = initialHealth; 
    healthBar.GetComponent<HealthBar>().updateHealth(health);
  }

  // Detect shots.
  void OnCollisionEnter(Collision col) {
    if (col.collider.tag == "bullet") {
      addHealth(-1);
    }
  }
}
