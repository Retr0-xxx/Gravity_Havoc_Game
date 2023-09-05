using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
       
    }

    public void CallControl() 
    {
        canvas.enabled = true;
    }

    public void closeControl() 
    {
      canvas.enabled=false;
    }
}
