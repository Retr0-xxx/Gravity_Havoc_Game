using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterWhile : MonoBehaviour
{
    
   

    float t = 0f;
    void Update()
    {
        t += Time.deltaTime;
        if (t > 4f)
        {
            gameObject.SetActive(false);
        }
    }
}
