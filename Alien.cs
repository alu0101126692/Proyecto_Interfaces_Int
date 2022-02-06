using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Invader
{
  public override void Start() {
    parentStart();
    health = 1f;
    speed = Random.Range(4f, 10f);
    range = Random.Range(5f, 10f);
    fireRatePerSec = Random.Range(0.5f, 1.5f);
    bulletSeparation = 1f;
  }
}
