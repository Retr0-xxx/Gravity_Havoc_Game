using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAim : MonoBehaviour
{
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    public Transform cameraLookAt;
    public Transform playerAimAt;
    public CinemachineVirtualCamera virtualCamera;
    float fieldOfView = 40;
    float FOV = 40;
    public static float targetFOV = 27f;
    public Transform righthandREF;
    public Transform righthandPOS;
    public Transform righrhandRestREF;
    public MultiAimConstraint weaponAimConstraint;
    public MultiAimConstraint bodyAimConstraint;
    public MultiRotationConstraint headRotConstraint;
    public GameObject crossHair;
    public static bool aimLocked = false;
    public static float offsetREF=0;
    public static float offsetPOS=0;
    public static RaycastHit hit;
    public static RaycastHit hit1;
    public static Ray ray;
   

    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       
    }
   

    private void Update()
    {

        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        offsetPOS = Mathf.Lerp(offsetPOS, offsetREF, Time.deltaTime * 6);
        offsetREF = Mathf.Lerp(offsetREF, 0, Time.deltaTime);
        cameraLookAt.rotation = Quaternion.Euler(new Vector3(yAxis.Value - offsetPOS, xAxis.Value, 0));

        rayCastAim();

        checkRightMouse();
    }

    void rayCastAim() 
    {
      
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        ray = Camera.main.ScreenPointToRay(screenCenter);
        Physics.Raycast(ray, out hit, 100f);
        Vector3 aimPoint = Camera.main.transform.position + ray.direction * 30;
        playerAimAt.position = Vector3.Lerp(playerAimAt.position,aimPoint,Time.deltaTime*20);
    }

    void checkRightMouse()
    {
        if (Input.GetMouseButton(1) || aimLocked == true)
        {
            headRotConstraint.weight = Mathf.Lerp(headRotConstraint.weight, 1f, Time.deltaTime * 5);
            bodyAimConstraint.data.offset = Vector3.Lerp(bodyAimConstraint.data.offset, new Vector3(-40,0,0),Time.deltaTime*3);

            crossHair.SetActive(true);

            FOV = Mathf.Lerp(FOV,targetFOV, Time.deltaTime * 7);

            fieldOfView = Mathf.Lerp(fieldOfView, 3f, Time.deltaTime*7);

            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().Damping = new Vector3(0.1f, 0.1f, 0.1f);
            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = fieldOfView;
            virtualCamera.m_Lens.FieldOfView = FOV;

            righthandPOS.position = Vector3.Lerp(righthandPOS.position, righthandREF.position, Time.deltaTime*7);
            righthandPOS.rotation = Quaternion.Lerp(righthandPOS.rotation, righthandREF.rotation, Time.deltaTime * 7);
            weaponAimConstraint.weight = 1;
        }
       else
        {
            headRotConstraint.weight = Mathf.Lerp(headRotConstraint.weight, 0f, Time.deltaTime * 5);
            bodyAimConstraint.data.offset = Vector3.Lerp(bodyAimConstraint.data.offset, new Vector3(0, 0, 0), Time.deltaTime * 3);

            crossHair.SetActive(false);
            FOV = Mathf.Lerp(FOV, 50f, Time.deltaTime * 7);
            fieldOfView = Mathf.Lerp(fieldOfView, 3.5f, Time.deltaTime*7);

            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().Damping = new Vector3(0.7f, 0.4f, 0.7f);
            virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = fieldOfView;
            virtualCamera.m_Lens.FieldOfView = FOV;

            righthandPOS.position = Vector3.Lerp(righthandPOS.position, righrhandRestREF.position, Time.deltaTime*7);
            righthandPOS.rotation = Quaternion.Lerp(righthandPOS.rotation, righrhandRestREF.rotation, Time.deltaTime * 7);
            weaponAimConstraint.weight = 0;
        }
    
    
    }
}
