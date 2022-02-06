using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
  public float size;
  
  // Start is called before the first frame update
  void Start()
  {
    GameObject master = GameObject.Find("SpaceMaster");
    size = master.GetComponent<SpaceMaster>().mapSize;
    
    GameObject top = GameObject.Find("Top");
    GameObject bot = GameObject.Find("Bot");
    GameObject left = GameObject.Find("Left");
    GameObject right = GameObject.Find("Right");
    GameObject back = GameObject.Find("Back");
    GameObject front = GameObject.Find("Front");

    top.transform.position = new Vector3(0, size, 0);
    bot.transform.position = new Vector3(0, -1 * size, 0);
    left.transform.position = new Vector3(-1 * size, 0, 0);
    right.transform.position = new Vector3(size, 0, 0);
    back.transform.position = new Vector3(0, 0, -1 * size);
    front.transform.position = new Vector3(0, 0, size);

    float scaled = size / 5;

    bot.transform.localScale = new Vector3(scaled, 10, scaled);
    top.transform.localScale = new Vector3(scaled, 10, scaled);
    left.transform.localScale = new Vector3(scaled, 10, scaled);
    right.transform.localScale = new Vector3(scaled, 10, scaled);
    back.transform.localScale = new Vector3(scaled, 10, scaled);
    front.transform.localScale = new Vector3(scaled, 10, scaled);
  }
}
