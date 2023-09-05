using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectPopUp : MonoBehaviour
{
    public float Fe;
    public float Pb;
    public float O;
    public float N;
    public float Au;
    public float healthSyringe;
    public float oxygenTank;



    bool isTriggerOn = false;
    public bool hasBeenCalled = false;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject[] toDestroy;
    public AudioSource collectSound;
    public Outline outline;

    private void Start()
    {
       canvas.SetActive(false);
    }

    private void Update()
    {
        if (isTriggerOn == true && Input.GetKeyDown(KeyCode.E))
        {
            if (hasBeenCalled == false)
            {
                collectSound.Play();
                collectItem();
            }
            
        }

        if(canvas2!=null)
         canvas2.transform.LookAt(transform.position + Camera.main.transform.forward);
      
        



        if (isTriggerOn == true && hasBeenCalled == false)
        {
            if(outline!=null)
               outline.enabled = true;
            canvas.SetActive(true);
            canvas.transform.LookAt(transform.position + Camera.main.transform.forward);

            if (canvas2 != null)
            canvas2.SetActive(false);
          

        }
        else
        {
            canvas.SetActive(false);
            if (outline != null)
                outline.enabled = false;
        }
    }

    void collectItem()
    {
        hasBeenCalled = true;
        foreach (var item in toDestroy)
        {
            Destroy(item, 0.1f);
        }
        Inventory.Fe += Fe;
        Inventory.Pb += Pb;
        Inventory.O += O;
        Inventory.N += N;
        Inventory.Au += Au;
        Inventory.oxygenTank += oxygenTank;
        Inventory.healthSyringe += healthSyringe;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        isTriggerOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggerOn = false;
            if (canvas2 != null)
                canvas2.SetActive(true);
        }
       
    }
}
