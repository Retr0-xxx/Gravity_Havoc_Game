using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDie : MonoBehaviour
{
    private SaveAndLoad saveAndLoad;

    private void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoad>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            saveAndLoad.ReloadScene();
        
        }
    }
}
