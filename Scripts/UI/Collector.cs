using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour,ISaveable
{
    public GameObject endNotification;
    public GameObject imageHash;
    public GameObject imafeArt;
    public float radius;
    int numberOfObj=0;
    public TextMeshProUGUI textMeshPro;
    AudioSource audioSource;
    bool hasBeenCalledA = false;
    bool isCon = false;
    DialougeEvent dialougeEvent;
    SaveAndLoad saveAndLoad;
    public string fileName;

    void Start()
    {
        saveAndLoad = FindObjectOfType<SaveAndLoad>();
        audioSource = GetComponent<AudioSource>();
        dialougeEvent = FindObjectOfType<DialougeEvent>();
    }

     void Update()
    {
      
        textMeshPro.text = numberOfObj.ToString()+"0%";

        if (!hasBeenCalledA && numberOfObj == 3 && isCon == false)
        { 
            StartCoroutine(collectDialouge());
            hasBeenCalledA = true;
            isCon = true;
        }

        if (numberOfObj == 10) 
        {
          endNotification.SetActive(true);
            PauseMenu.isPaused = true;
        
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collect")) 
        {
          numberOfObj++;
            audioSource.Play();
           other.tag = "Untagged";
        }
     
    }

    IEnumerator collectDialouge() 
    {
        dialougeEvent.dialougeTriggered.Invoke(fileName);

        while (imafeArt.activeSelf || imageHash.activeSelf) 
        {
           yield return new WaitForSeconds(0.5f);
        }

        saveAndLoad.save();
        SceneManager.LoadScene(3);
    }

    public object CaptureState()
    {
        return new saveData
        {
            SaveBool = hasBeenCalledA,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        hasBeenCalledA = saveData.SaveBool;

    }

    [Serializable]
    struct saveData
    {
        public bool SaveBool;
    }



}
