using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class TextPopUp : MonoBehaviour
{
    string[] textArray;
    TextMeshProUGUI textMeshPro;
    TextMeshProUGUI Title;
    public string fileName;
    public string title;
    bool isTriggerOn = false;
    bool hasBeenCalled = false;
     GameObject textPopUp;
    public GameObject canvas;
    public AudioSource readSound;
    private void Awake()
    {
        fileName = Application.dataPath + "/allText/" +fileName;
        textPopUp = GameObject.FindWithTag("UItext");
        TextMeshProUGUI[] components = textPopUp.GetComponentsInChildren<TextMeshProUGUI>();
        Title = components[0];
        textMeshPro = components[1];
        
    }

    private void Start()
    {
        textPopUp.SetActive(false);
    }

    private void Update()
    {
        if (isTriggerOn == true && Input.GetKeyDown(KeyCode.E)) 
        {
            if (hasBeenCalled == false)
            {
                readFromFile();
               
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            textPopUp.SetActive(false);
            PauseMenu.isPaused = false;
        }

        if (isTriggerOn == true)
        {
            canvas.SetActive(true);
            canvas.transform.LookAt(transform.position+Camera.main.transform.forward);

        }
        else 
        {
            canvas.SetActive(false);
        }
    }
    public void readFromFile() 
    {
       
        readSound.Play();
        hasBeenCalled = true;
        textPopUp.SetActive(true);
        PauseMenu.isPaused = true;
        Title.text = title;
        try
        {
            textArray = File.ReadAllLines(fileName);

            foreach (string line in textArray)
            {

                textMeshPro.text = textMeshPro.text + line + '\n';
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception caught: " + ex.Message);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isTriggerOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isTriggerOn = false;

        hasBeenCalled = false;
    }
}
