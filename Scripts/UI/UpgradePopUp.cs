using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePopUp : MonoBehaviour
{
    bool isTriggerOn = false;
    public GameObject upgradePopUp;
    public GameObject canvas;
    public AudioSource readSound;
    private void Awake()
    {
      
     

    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (isTriggerOn == true && Input.GetKeyDown(KeyCode.E))
        {
            upgradePopUp.SetActive(true);
            PauseMenu.isPaused = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            upgradePopUp.SetActive(false);
            PauseMenu.isPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (isTriggerOn == true)
        {
            canvas.SetActive(true);
            canvas.transform.LookAt(transform.position + Camera.main.transform.forward);

        }
        else
        {
            canvas.SetActive(false);
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

    }
}
