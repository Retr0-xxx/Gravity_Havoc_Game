using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCursor : MonoBehaviour
{
    public Transform headAim;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

   
    void Update()
    {
        Vector3 mousePOS = Input.mousePosition;
        mousePOS.z = 0.25f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePOS);
        
        
        headAim.position = Vector3.Lerp(headAim.position,worldPosition,Time.deltaTime*2);
    }
}
