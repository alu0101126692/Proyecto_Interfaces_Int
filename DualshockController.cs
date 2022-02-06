using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class DualShockController : MonoBehaviour {

  public bool experiencePaused;
  public Experience currentExperience;
  public VoiceController voice;
  public int stage;

  const string triangleButton = "joystick button 3";
  const string startButton = "joystick button 9";
  const string circleButton = "joystick button 2";
  const string L1Button = "joystick button 4";
  const string R1Button = "joystick button 5";

  void Start() {
    experiencePaused = false;
  }

  void Update() {
    if (Input.GetButtonDown(triangleButton)) {
      voice.startListening();
    }
    if (Input.GetButtonDown(startButton)) {
      if (experiencePaused) {
        currentExperience.receiveOrder("pausa");
        experiencePaused = false;
      } else {
        currentExperience.receiveOrder("reanudar");
        experiencePaused = true;
      }
    }
    if (experiencePaused && Input.GetButtonDown(circleButton)) {
      currentExperience.receiveOrder("salir");
    }
    if (Input.GetButtonDown(L1Button)) {
      currentExperience.receiveOrder("bajar volumen");
    }
    if (Input.GetButtonDown(R1Button)) {
      currentExperience.receiveOrder("subir volumen");
    }
  }
}