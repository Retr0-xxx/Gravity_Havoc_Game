using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ShowNotificatoin : MonoBehaviour
{
    public GameObject Notification;
    public GameObject Popup;
    void Update()
    {
        try
        {

            if (transform.CompareTag(firstPersonCam.hit.collider.transform.tag) && firstPersonCam.TargetAquired)
            {
                Notification.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Popup.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }

            }
            else
            {
                Notification.SetActive(false);
            }
        }
        catch { }
    }
}
