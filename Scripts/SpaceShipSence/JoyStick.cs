using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    float SVertical = 0f;
    float SHorizontal = 0f;
    
    void Update()
    {
        
        float inputX = Input.GetAxis("Mouse X") * 70f;
        float inputY = Input.GetAxis("Mouse Y") * 70f;

    

        SVertical += inputY;
        SVertical = Mathf.Clamp(SVertical, -20f, 20f);
        SHorizontal += inputX;
        SHorizontal = Mathf.Clamp(SHorizontal, -20f, 20f);

        transform.localRotation = Quaternion.Lerp(transform.localRotation,Quaternion.Euler( SVertical,SHorizontal, 0f), Time.deltaTime*4f);
    }
}
