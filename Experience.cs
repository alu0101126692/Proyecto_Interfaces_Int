using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Experience : MonoBehaviour {
  

  /*
  public string XButton = "joystick button 1";
  public string circleButton = "joystick button 2";
  public string triangleButton = "joystick button 3";
  public string L1Button = "joystick button 4";
  public string R1Button = "joystick button 5";
  public string startButton = "joystick button 9";
  */
  
  public bool experiencePaused;
  
  abstract public void receiveOrder(string order);
}
