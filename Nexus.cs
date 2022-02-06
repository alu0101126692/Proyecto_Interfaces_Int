using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Nexus : MonoBehaviour {
  public float health;
  public float mapSize;
  public int points;
  public float initialNexusHp = 10f;
  public float maxHp = 100f;
  public GameObject nexusBar, pointsText, explosion;
  public bool invulnerable = false;
  public bool dead = false;

  public AudioSource audio;

  void Start() {
    mapSize = GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().mapSize;
    transform.position = new Vector3(0, -mapSize, 0);
    health = initialNexusHp;
    points = 0;
    nexusBar = GameObject.Find("NexusBar");
    nexusBar.GetComponent<HealthBar>().setMaxHealth(maxHp); 
    pointsText = GameObject.Find("PointText");
  }

  void Update() {
    pointsText.GetComponent<Text>().text = points.ToString();
    setHealth(health + 2 * Time.deltaTime);

    if (health <= 0 && !dead) {
      dead = true;
      destroyNexus(); 
    }
    else if (health >= maxHp) 
      capture();
  }

  void destroyNexus() {
    Instantiate(explosion, transform.position, Quaternion.identity);
    GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().endGame();
    transform.GetChild(0).gameObject.SetActive(false);
  }

  IEnumerator invulnerability () {
    invulnerable = true;
    yield return new WaitForSeconds(5f);
    invulnerable = false;
  }


   public void captureInput(InputAction.CallbackContext value) {
    if (value.started) {
      capture();
    } 
        
  }
  public void capture() {
    // Add one point.
    audio.Play();
    points++;
    GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().handlePoints(points);

    // Restart nexus.
    setHealth(10f);
    StartCoroutine(invulnerability());
    transform.position =  new Vector3(
      Random.Range(-mapSize, mapSize),
      Random.Range(-mapSize, mapSize),
      Random.Range(-mapSize, mapSize)
    );
    GameObject.Find("Main Camera").GetComponent<Player>().addHealth(100);
  }


  void OnCollisionEnter(Collision col) {
    // Gets shot.
    if (col.collider.tag == "bullet") {
      if (!invulnerable) setHealth(health - 5);
    }
  }

  void setHealth (float newHealth) {
    health = newHealth;
    nexusBar.GetComponent<HealthBar>().updateHealth(health);
  }

}
