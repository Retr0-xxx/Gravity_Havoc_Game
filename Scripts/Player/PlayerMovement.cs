using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;


public class PlayerMovement : MonoBehaviour, ISaveable
{
  
    public float speed;
    public Transform GameCamera;
    bool locked = false;
    public Rigidbody Rigidbody;
    Vector3 axis;
    Vector3 direction;
    public Vector3 KeyboardDirection;
    Quaternion playerRotation;
    public Animator animator;
    public GameObject secondCAM;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        axis = Vector3.zero;
        axis.y = Input.GetAxisRaw("Jump");



          direction = new Vector3(horizontal, 0f, vertical).normalized;

            direction = playerRotation * direction;

            KeyboardDirection = direction;

            Rigidbody.AddForce(direction * speed);

            Rigidbody.AddForce(axis * speed);

       
            Quaternion targetRot = Quaternion.Lerp(Rigidbody.rotation, Quaternion.Euler(0f,GameCamera.eulerAngles.y, 0f), Time.deltaTime * 3f);
            Rigidbody.MoveRotation(targetRot);
        

        playerRotation = Quaternion.Euler(0f, GameCamera.eulerAngles.y, 0f);
    }

    private void Update()
    {

        if (Input.GetButtonDown("lock camera") == true)
        {
            locked = !locked;
            secondCAM.SetActive(locked);
        }

        float x = Vector3.Dot(direction, transform.forward);
        float y = Vector3.Dot(direction, transform.right);

        animator.SetFloat("velocityX", x, 0.4f, Time.deltaTime);
        animator.SetFloat("velocityY", y, 0.4f,Time.deltaTime);
    }

    public object CaptureState()
    {
        return new saveData
        {
            playerPosition_x = Rigidbody.transform.position.x,
            playerPosition_y = Rigidbody.transform.position.y,
            playerPosition_z = Rigidbody.transform.position.z, 

            playerRotation_x = Rigidbody.transform.eulerAngles.x,
            playerRotation_y = Rigidbody.transform.eulerAngles.y,
            playerRotation_z = Rigidbody.transform.eulerAngles.z,
           dashTime = Dash.dashTime,
        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        Rigidbody.transform.position = new Vector3(saveData.playerPosition_x, saveData.playerPosition_y, saveData.playerPosition_z);
        Rigidbody.transform.eulerAngles = new Vector3(saveData.playerRotation_x, saveData.playerRotation_y, saveData.playerRotation_z);
        Rigidbody.velocity = Vector3.zero;
        Dash.dashTime = saveData.dashTime;
    }

     [Serializable] struct saveData
    {
      public float playerPosition_x;
      public float playerPosition_y;
      public float playerPosition_z;
      public float playerRotation_x;
      public float playerRotation_y;
      public float playerRotation_z;
      public float dashTime;
    }

   
}
