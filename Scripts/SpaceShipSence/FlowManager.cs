using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public GameObject AfterWhile;
    public GameObject roomGroup;
    public GameObject[] dialougues;
    public GameObject ship;
    public Transform movedTransform;
    public GameObject music1;
    public GameObject music2;
    public GameObject Object1;
    public GameObject Object;
    

    
    void Update()
    {
        if (checkIfAllFalse()) 
        {
           ship.transform.position = movedTransform.position;
           ship.transform.rotation = movedTransform.rotation;
           ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
           ship.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
           roomGroup.SetActive(true);
           AfterWhile.SetActive(true);
            music1.SetActive(false);
            music2.SetActive(true);
            Object.SetActive(false);
            Object1.SetActive(true);
           gameObject.SetActive(false);
        }
    }

    bool checkIfAllFalse() 
    {
        foreach (GameObject obj in dialougues) 
        {
            if (obj.activeSelf == true)
                return false;
        }
        return true; 
    }
}
