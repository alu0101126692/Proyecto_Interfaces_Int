using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {
  public GameObject alien, ship;
  public float mapSize;
  public int numberOfShips, numberOfAliens;
  public float alienSpawnRate = 5f;
  public float shipSpawnRate = 20f;

  void Start() {
    numberOfShips = 0;
    numberOfAliens = 0;
    mapSize = GameObject.Find("SpaceMaster").GetComponent<SpaceMaster>().mapSize - 10;
    StartCoroutine(spawnAlien());
    StartCoroutine(spawnShip());
  }


  IEnumerator spawnAlien() {
    yield return new WaitForSeconds(alienSpawnRate);
    Instantiate(alien, calcRandomPosition(), Quaternion.identity);
    numberOfAliens++;
    StartCoroutine(spawnAlien());
  }

  IEnumerator spawnShip() {
    yield return new WaitForSeconds(shipSpawnRate);
    Instantiate(ship, calcRandomPosition(), Quaternion.identity);
    numberOfShips++;
    StartCoroutine(spawnShip());
  }

  public void updateSpawnRate(int points) {
    switch (points) {
      case 1:
      alienSpawnRate = 3.85f; shipSpawnRate = 15f;  break; 
      case 2:
      alienSpawnRate = 2.85f; shipSpawnRate = 10f;  break;
      case 3:
      alienSpawnRate = 2f; shipSpawnRate = 5f;  break;
      case 4:
      alienSpawnRate = 1f; shipSpawnRate = 1f;  break;
      default:
      alienSpawnRate = 5f; shipSpawnRate = 20f;  break;
    }
    
  }

  Vector3 calcRandomPosition() {
    return new Vector3(
      Random.Range(-mapSize, mapSize),
      Random.Range(-mapSize, mapSize),
      Random.Range(-mapSize, mapSize)
    );
  }
}
