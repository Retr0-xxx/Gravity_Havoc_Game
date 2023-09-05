using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class moveAround : MonoBehaviour
{
   public Rigidbody body;
    Vector3 rot;
    int chance;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        rot = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        chance = Random.Range(0,10);
    }

    private void Update()
    {
        if (chance < 8)
        {
          if(Input.GetKey(KeyCode.F)==false)
          body.AddTorque(rot / 3f);
        }

    }



}
