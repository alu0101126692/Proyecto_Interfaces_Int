using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;



public class RythmController : Experience
{
    public List<float> notesList;
    int currentNote = 0;
    public float noteTimer;
    public Image buttonPress;
    public Image buttonNotPress;
    public GameObject Note;
    public Transform parentObject;

    public bool buttonActive;

    public Text pointText;

    public float offsetTime; // Tiempo que tarda la nota en llegar al medio
   
    public float speed; // Velocidad de las notas

    public float points = 0; // Puntos actuales

    public List<GameObject> noteObjects; // Lista del objeto que representa las notas

    public float shakeForce; // Fuerza necesaria con la que se debe agitar el movil para que se toque la nota

    public TextMeshPro endText;
    public TextMeshPro endPoints;


    public VideoPlayer video;
    public AudioSource audio;

    public GameObject panelMenu;    
    // Start is called before the first frame update
    void Start()
    {
        noteObjects = new List<GameObject>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        /*
        float distance = 344 - (-199.366f);
        offsetTime = distance / (speed);
        */
    }

    // Abre el menu de pausa
    void openPauseMenu() {
        experiencePaused = true;
        video.Pause();
        audio.Pause();
        panelMenu.SetActive(true);
        pointText.enabled = false;
        for (int i = 0; i < parentObject.childCount; i++) {
            parentObject.GetChild(i).GetComponent<NoteAdvance>().pause();
        }
    }
    // Reanuda el juego
    void resume() {
        experiencePaused = false;
        video.Play();
        audio.Play();
        panelMenu.SetActive(false);
        pointText.enabled = true;
        for (int i = 0; i < parentObject.childCount; i++) {
            parentObject.GetChild(i).GetComponent<NoteAdvance>().speed = speed;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (!experiencePaused) {
            noteTimer += Time.deltaTime;

            manageButtonPress();

            if (currentNote < notesList.Count) {
                spawnNotes();
            } else if (parentObject.childCount == 0) {
                endScreen();
            }
        }

        
            
    }
    
    public override void receiveOrder(string order) {
        if (order == "pausa") {
            openPauseMenu();
        }
        if (experiencePaused) {
            if (order == "reanudar") {
                resume();
            }
            if (order == "salir") {
                SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
            }
        }
        
    }
    // Administra la pantalla de resultado
    private void endScreen() {
        endText.enabled = true;
        endPoints.enabled = true;
        buttonNotPress.enabled = false;
        buttonPress.enabled = false;
        pointText.enabled = false;
        endPoints.text = "Points: " + pointText.text;
    }
    private void manageButtonPress() {

        
        
        Vector3 shakeAcc = Input.acceleration;

        if (shakeAcc.sqrMagnitude >= shakeForce) { 
            
            buttonActive = true;
            manageNote();
        }   

        
    }

       // Instancia las notas
    private void spawnNotes() {

        if (noteTimer >= notesList[currentNote] - offsetTime) {
            GameObject actualNote = Instantiate(Note);
            actualNote.name = currentNote.ToString();
            actualNote.transform.SetParent(parentObject, false);
            noteObjects.Add(actualNote);
            currentNote++;

            // Calcular el tiempo que tardaria en llegar con la velocidad actual
            actualNote.GetComponent<NoteAdvance>().speed = speed; 
        }

        
    }
    
    
    public void buttonPressManage(InputAction.CallbackContext value) {
        if (value.started) {
        manageNote();
        } 
    }
    
    // Maneja la pulsacion de notas
    public void manageNote() {
        buttonNotPress.enabled = false;
        buttonPress.enabled = true;
        bool finded = false;
        float pressedTime = noteTimer;
        int noteID = 0;
        float pointReduction = 0;
        for (int i = 0; i < notesList.Count; i++) {
            if (notesList[i] >= pressedTime - pressRange && notesList[i] <= pressedTime + pressRange) {
                noteID = i;
                finded = true;

                pointReduction = Mathf.Abs(notesList[i] - pressedTime);
                break;
            }
        }
            
        if (finded) { 
            for (int i = 0; i < noteObjects.Count; i++) {
                if (noteObjects[i] != null)
                    if (noteID.ToString() == noteObjects[i].name) {
                        GameObject actualObject = noteObjects[i];
                        noteObjects.RemoveAt(i);
                        Destroy(actualObject);
                        points += 100 - (int)((pointReduction) * 100);
                        pointText.text = points.ToString();
                    }
            }
        }

        StartCoroutine(endNoteVisual());
    }

    private IEnumerator endNoteVisual() {
        yield return new WaitForSeconds(0.1f);
        buttonNotPress.enabled = true;
        buttonPress.enabled = false;
    }
}


