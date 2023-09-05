using System;
using UnityEngine;

public class firstPersonCam : MonoBehaviour
{
    public GameObject crossHair;
    public Transform Screen1;
    public float mouseSensitivity;
    float CamVertical = 0f;
    float CamHorizontal = 0f;
    public static RaycastHit hit;
    public static bool TargetAquired= false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            CamVertical -= inputY;
            CamVertical = Mathf.Clamp(CamVertical, -90f, 40f);
            CamHorizontal += inputX;
            CamHorizontal = Mathf.Clamp(CamHorizontal, -90f, 90f);

            transform.localEulerAngles = Vector3.right * CamVertical + new Vector3(0, 1, 0) * CamHorizontal;

            Screen1.localRotation = Quaternion.Lerp(Screen1.localRotation, Quaternion.Euler(-70, 0, 0), Time.deltaTime*2);
       
            crossHair.SetActive(true);
           doRayCast();

        }
        else
        {
            crossHair.SetActive (false);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(-8, 0, 0), Time.deltaTime * 2);
            Screen1.localRotation = Quaternion.Lerp(Screen1.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime*2);
            TargetAquired = false;
        }
    }

    void doRayCast() 
    {
        var screenMiddle = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenMiddle);
        
        if (Physics.Raycast(ray))
            TargetAquired = true;
        else
            TargetAquired = false;

        if (TargetAquired == true)
        {
            Physics.Raycast(ray, out hit);
        }
      
      //  Debug.Log(hit.collider.transform.tag);
        Debug.DrawRay(Camera.main.transform.position, ray.direction*999,Color.red,Time.deltaTime);
    }
}
