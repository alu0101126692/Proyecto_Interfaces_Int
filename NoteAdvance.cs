using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAdvance : MonoBehaviour
{
    
    public float speed;
    public float noteTime; // Tiempo que estará la nota
    // Update is called once per frame
    public float timer;

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= noteTime) {
            Destroy(this.gameObject);
        }
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    public void pause() {
        speed = 0;
    }

    
    
}
