using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriggers : MonoBehaviour,ISaveable
{
    bool isCon =false;
    public GameObject tutorialIMG;
    bool hasBeenCalled = false;

    private void Update()
    {
        if (hasBeenCalled) 
        {
          isCon = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (!isCon)
                StartCoroutine(Tutorial());
        }
    }

    IEnumerator Tutorial() 
    {
        isCon = true;
       tutorialIMG.SetActive(true);
        PauseMenu.isPaused = true;
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        hasBeenCalled = true;
        PauseMenu.isPaused = false;
        tutorialIMG.SetActive(false);
        isCon = false;
        
    }

    public object CaptureState()
    {
        return new saveData
        {
            SaveBool = hasBeenCalled,

        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        hasBeenCalled = saveData.SaveBool;

    }

    [Serializable]
    struct saveData
    {
        public bool SaveBool;
    }
}
