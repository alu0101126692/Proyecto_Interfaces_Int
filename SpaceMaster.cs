using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceMaster : Experience
{
  public GameObject alien, ship;
  public float mapSize = 100f;

  public Text gameOverText;
  public Text youWinText;

  // Start is called before the first frame update
  void Start() {
    gameOverText = GameObject.Find("GameOver").GetComponent<Text>();
    gameOverText.enabled = false;
    youWinText = GameObject.Find("YouWin").GetComponent<Text>();
    youWinText.enabled = false;
  }

  // Update is called once per frame
  void Update() {
  }

  public void handlePoints (int points) {
    GameObject.Find("Spawner").GetComponent<Spawner>().updateSpawnRate(points);
    switch (points) {
      case 1: // - Disparo quintuple.  Aprox 25 balas/sec.
        GameObject.Find("Main Camera").GetComponent<Player>().fireRate = 5;
        GameObject.Find("Main Camera").GetComponent<Player>().bursts = 1;
        GameObject.Find("Main Camera").GetComponent<Player>().burstBulletScale = 2;
        break; 
      case 2: // - Aprox 50 balas/sec.  
        GameObject.Find("Main Camera").GetComponent<Player>().fireRate = 10;
        GameObject.Find("Main Camera").GetComponent<Player>().bursts = 1;
        GameObject.Find("Main Camera").GetComponent<Player>().burstBulletScale = 2;
        break;
      case 3: // - Disparo por ráfagas.  Aprox 125 balas/sec.
        GameObject.Find("Main Camera").GetComponent<Player>().fireRate = 5;
        GameObject.Find("Main Camera").GetComponent<Player>().bursts = 5;
        GameObject.Find("Main Camera").GetComponent<Player>().burstBulletScale = 2;
        break;
      case 4: // - Disparo espagueti. Aprox 330 balas/sec.
        GameObject.Find("Main Camera").GetComponent<Player>().fireRate = 30;
        GameObject.Find("Main Camera").GetComponent<Player>().bursts = 1;
        GameObject.Find("Main Camera").GetComponent<Player>().burstBulletScale = 5;
        break;
      case 5:
        win();
        break;
      default:
        break;
    }
  }

  public void win() {
    youWinText.enabled = true;
  }

  public void endGame() {
    gameOverText.enabled = true;
  }

  public void exitGame() {
    SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
  }
  public override void receiveOrder(string order) {}
}
