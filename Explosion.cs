using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
  void Start() {
    StartCoroutine(selfDestruct());
  }

  IEnumerator selfDestruct() {
    yield return new WaitForSeconds(2f);
    Destroy(gameObject);
  }
}
