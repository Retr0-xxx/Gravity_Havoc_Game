using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public PlayerShoot playerShoot;
    public AudioSource pauseSound;
    public static bool isMenuOut = false;
    public GameObject PauseCanvas;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseSound.Play();
            if (Inventory.stat == false )
            {
                isPaused = !isPaused;
            }
            isMenuOut = !isMenuOut;
            PauseCanvas.SetActive(isMenuOut);

            if (isMenuOut == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (isMenuOut == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

            if (isPaused==true)
            {
               
                Time.timeScale = 0f;
               playerShoot.enabled = false;
            }
            else
            {
              if(Time.timeScale!=1f)
                Time.timeScale = 1f;
            playerShoot.enabled = true;
        }
        
    }
}
