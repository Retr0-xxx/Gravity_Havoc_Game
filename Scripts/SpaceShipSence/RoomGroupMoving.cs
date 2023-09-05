using Polarith.AI.Package;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGroupMoving : MonoBehaviour
{
    TriggerDialougeText triggerDialougeText;
    public string fileName;
    public string fileName2;
    public Transform launcher;
    public GameObject Rocket;
    float spd = 0f;
    public Transform fwd;
    ShipController shipController;
    float t = 0f;
    bool isOn=false;

    private void Start()
    {
        
        triggerDialougeText = FindObjectOfType<TriggerDialougeText>();
        shipController = FindObjectOfType<ShipController>();
        StartCoroutine(stopship());
    }
    void Update()
    {
        t += Time.deltaTime;

        if (t > 5f)
        {
            spd = Mathf.Lerp(spd, 55f, Time.deltaTime * 10);
            transform.Translate(fwd.forward * Time.deltaTime * spd);
        }
        if (isOn == false && t > 5) 
        {
            StartCoroutine(triggerDialougeText.typeDialouge(fileName));
            isOn = true;
        }

       

    }

    IEnumerator stopship() 
    {
        shipController.enabled = false;
        yield return new WaitForSeconds(15f);
        shipController.enabled=true;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(launchTen());
          
        }
    }

    IEnumerator launchTen() 
    {
        StartCoroutine(triggerDialougeText.typeDialouge(fileName2));
        for (int i = 0; i < 999; i++) 
        {
           Instantiate(Rocket,launcher.transform.position, Quaternion.Euler(Vector3.up));
           yield return new WaitForSeconds(1.5f);
        }
    
    }
}
