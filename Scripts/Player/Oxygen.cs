using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour,ISaveable
{
    public float oxgen;
    public float maxOxygen;
    public PlayerHealth playerHealth;
    public AudioSource takeOxygen;

    private void Start()
    {
        oxgen = maxOxygen;
    }

    private void Update()
    {
        if (oxgen > 0)
             oxgen -= Time.deltaTime;

        if (oxgen < 0.5f)
            playerHealth.health -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X) == true && Inventory.oxygenTank > 0) 
        {
            Inventory.oxygenTank--;
            takeOxygen.Play();
            oxgen += 50;
            if (oxgen > maxOxygen)
                oxgen = maxOxygen;
        }
    }

    public object CaptureState()
    {
        return new saveData
        {
            oxygen = oxgen,
            maxOxygen = maxOxygen,
        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        oxgen = saveData.oxygen;
        maxOxygen = saveData.maxOxygen;
    }

    [Serializable]
    struct saveData
    {
        public float oxygen;
        public float maxOxygen;
    }
}
