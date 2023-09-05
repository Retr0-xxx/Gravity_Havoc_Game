using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollsionAngle : MonoBehaviour
{
    public static float rotation;
    public Transform viewPoint;
    Vector3 direction;
    private void OnCollisionEnter(Collision collision)
    {


        ContactPoint contactPoint = collision.GetContact(0);

      
         direction = contactPoint.point - viewPoint.transform.position;

        
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        rotation = angle;

       


    }

    private void Update()
    {
        Debug.DrawRay(viewPoint.position, direction*999f, Color.red);
    }


}
