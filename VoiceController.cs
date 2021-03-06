using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour {

  public string language = "es-ES";
  public bool isListening = false;
  private string audioIn;

  public Image microphoneIcon;

  private float recognitionTime = 5f;
  

  public Experience currentExperience;

  void Start() {
    Setup(language);

    SpeechToText.instance.onResultCallback = onFinalSpeechResult;
    SpeechToText.instance.onPartialResultsCallback = onPartialSpeechResult;
    
    checkPermission();
    
  }
  
  
  void checkPermission() {
    if (!Permission.HasUserAuthorizedPermission(Permission.Microphone)) {
      Permission.RequestUserPermission(Permission.Microphone);
    }
  }

  void Update() {
    if (Input.touchCount > 0 && !isListening) {
      startListening();
      isListening = true;
    }

    

    
    
    
  }
  
  public void startListening() {
    SpeechToText.instance.StartRecording();
    microphoneIcon.enabled = true;
    StartCoroutine(endRecognitionByTime());
  }

  public void stopListening() {
    currentExperience.receiveOrder(audioIn);
    isListening = false;
    SpeechToText.instance.StopRecording();
    microphoneIcon.enabled = false;
  }
  
  // Se ejecuta cuando la API del reconocimiento de voz termina de reconocer la palabra
  void onFinalSpeechResult(string result) {
    audioIn = result;
    stopListening();
  }    
  
  // Se ejecuta cuando la API del reconocimiento de voz reconoce parcialmente la palabra
  void onPartialSpeechResult(string result) {
    audioIn = result;
    stopListening();
  }

  void Setup(string code) {
    SpeechToText.instance.Setting(code);
  }
  
  // Termina el reconocimiento de voz si no se han obtenido resultados despues de unos segundos
  private IEnumerator endRecognitionByTime() {
    yield return new WaitForSeconds(recognitionTime);
    if (isListening) {
      stopListening();
    }

  }
}
