using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashlight;
    bool status = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            status = !status;
            flashlight.SetActive(status);
        
        }
    }
}
