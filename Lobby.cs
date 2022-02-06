using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.Video;



public class Lobby : MonoBehaviour {


  public Transform sceneParent;
  void Start() {
  }

  void Update() {
    playGif();
  }
  
  // Inicia el gif de los objetos cuando se miran
  private void playGif() {
    RaycastHit hit;
    Debug.DrawLine(transform.position, transform.position + transform.forward * 500, Color.red);
    
    if (Physics.Raycast(transform.position, transform.forward, out hit, 500f)) {
      hit.collider.GetComponent<VideoPlayer>().Play();
    } else {
      for (int i = 0; i < sceneParent.childCount; i++) {
        sceneParent.GetChild(i).GetComponent<VideoPlayer>().Pause();
      }
    }
  }
  
  // Selecciona la escena y la carga
  public void selectScene() {
    RaycastHit hit;
    Debug.DrawLine(transform.position, transform.position + transform.forward * 500, Color.red);
    
    if (Physics.Raycast(transform.position, transform.forward, out hit, 500f)) {
      string name = hit.collider.name;
      Debug.Log(name);
      SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
  }
  

}
