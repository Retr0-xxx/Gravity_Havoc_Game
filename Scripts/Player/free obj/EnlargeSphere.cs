using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeSphere : MonoBehaviour
{
    bool direction = true;

    void Update()
    {
           if(direction == true)
             transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2.5f, 2.5f, 2.5f), Time.deltaTime*1.5f);
           else
             transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime*1.5f);

           if(transform.localScale.x>2.45)
            direction =!direction;

           if(transform.localScale.x < 1.05)
            direction = !direction;
    }

   
}
