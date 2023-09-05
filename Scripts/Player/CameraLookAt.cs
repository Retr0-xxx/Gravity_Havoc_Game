using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Vector3 offset;
    public Rigidbody playerRB;
    public Rigidbody targetRB;
   
    void FixedUpdate()

    {
   
        targetRB.MovePosition(playerRB.position);
    }
}
