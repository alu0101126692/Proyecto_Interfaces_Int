using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Invader
{
  public override void Start() {
    parentStart();
    health = 10f;
    speed = Random.Range(2f, 6f);
    range = Random.Range(15f, 20f);
    fireRatePerSec = Random.Range(2f, 3f);
    bulletSeparation = 10f;
  }
}
