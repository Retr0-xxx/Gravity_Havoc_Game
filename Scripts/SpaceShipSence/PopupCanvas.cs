using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class PopupCanvas : MonoBehaviour
{
    public GameObject clickStat;

    public GameObject popUp;
    public TextMeshProUGUI textMeshPro;
    public string[] mails;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            popUp.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void pressBTN0() 
    {
       textMeshPro.text = mails[0];
       clickStat.SetActive(false);
    }
    public void pressBTN1()
    {
        textMeshPro.text = mails[1];
        clickStat.SetActive(false);
    }
    public void pressBTN2()
    {
        textMeshPro.text = mails[2];
        clickStat.SetActive(false);
    }
    public void pressBTN3()
    {
        textMeshPro.text = mails[3];
        clickStat.SetActive(false);
    }
}
