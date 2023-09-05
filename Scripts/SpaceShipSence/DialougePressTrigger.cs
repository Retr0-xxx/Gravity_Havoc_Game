using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougePressTrigger : MonoBehaviour
{
    public string fileName;
    public GameObject Notification;
    public GameObject circleCanvas;
    TriggerDialougeText triggerDialougeText;
    bool hasBeenCalled = false;
    public AudioSource interactAudio;
    private void Start()
    {
        triggerDialougeText = FindObjectOfType<TriggerDialougeText>();
    }
    void Update()
    {
        try
        {
            if (transform.CompareTag(firstPersonCam.hit.collider.transform.tag) && firstPersonCam.TargetAquired)
            {
                Notification.SetActive(true);
                circleCanvas.SetActive(false);

                if (Input.GetKeyDown(KeyCode.E) && triggerDialougeText.IsCon == false)
                {
                    interactAudio.Play();   
                    StartCoroutine(triggerDialougeText.typeDialouge(fileName));

                   hasBeenCalled = true;
                }


            }
            else
            {
                Notification.SetActive(false);
                circleCanvas.SetActive(true);
            }

            if (hasBeenCalled) 
            {
                if (triggerDialougeText.IsCon == false) 
                {
                 gameObject.SetActive(false);
                }
            }
        }
        catch { }
        
    }
}
