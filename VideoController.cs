using UnityEngine;
using System.Collections;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoController : Experience {

  public VideoPlayer videoPlayer;
  public Material material;
  public float currentVolume;
  public float volumeChangeRate;
  
  void Start () {
    //videoPlayer = new VideoPlayer();
    //videoPlayer.url = "https://www.youtube.com/watch?v=y6ZnPuvRWh4&t=532s";
    currentVolume = videoPlayer.GetDirectAudioVolume(0);
    volumeChangeRate = 0.1f;
  }

  void Update () {
    
  }

  public override void receiveOrder(string order) {
    if (order == "pausa") {
      videoPlayer.Pause();
    }
    if (order == "reanudar") {
      videoPlayer.Play();
    }
    if (order == "salir") {
      SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    if (order == "subir volumen") {
      if (currentVolume + volumeChangeRate > 1f) {
        videoPlayer.SetDirectAudioVolume(0, 1f);
        currentVolume = 1f;
      } else {
        videoPlayer.SetDirectAudioVolume(0, currentVolume + volumeChangeRate);
        currentVolume += volumeChangeRate;
      }
    }
    if (order == "bajar volumen") {
      if (currentVolume - volumeChangeRate < 0) {
        videoPlayer.SetDirectAudioVolume(0, 0f);
        currentVolume = 0f;
      } else {
        videoPlayer.SetDirectAudioVolume(0, currentVolume - volumeChangeRate);
        currentVolume -= volumeChangeRate;
      }
    }
  }
}
