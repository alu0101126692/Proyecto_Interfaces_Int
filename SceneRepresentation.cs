using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRepresentation : MonoBehaviour
{

    public Transform target;
    void Start() {
        transform.LookAt(target.position);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
