using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingCanvas : MonoBehaviour
{
    public GameObject BTNcanvas;
    public TMP_Dropdown dropdown;
    Resolution[] resolutions;
    List<Resolution> filteredRes;

   
    int currnetResIndext;

    private void Start()
    {
        initialRes();
    }

    void initialRes()
    {
        resolutions = Screen.resolutions;
        filteredRes = new List<Resolution>();
        dropdown.ClearOptions();
      

        for (int i = 0; i < resolutions.Length; i++)
        {
           
                filteredRes.Add(resolutions[i]);
            
        }

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = filteredRes[i].width + "x" + filteredRes[i].height;
            options.Add(resolutionOption);
            currnetResIndext = i;
        }

        dropdown.AddOptions(options);
        dropdown.value = currnetResIndext;
        dropdown.RefreshShownValue();
    }

    public void setRes(int ResIndex) 
    {
      Resolution resolution = filteredRes[ResIndex];
      Screen.SetResolution(resolution.width, resolution.height, true);
        Debug.Log(Screen.currentResolution);
    }

    public void setRefresh(int RefreshIndex)
    {
       

        switch (RefreshIndex) 
        { 
            case 1:
                Application.targetFrameRate = 30;
                break;

            case 2:
                Application.targetFrameRate= 60;
                break;

            case 3:
                Application.targetFrameRate= 120;
                break;

            case 0:
                Application.targetFrameRate = -1;
                break;
        
        
        }

        initialRes();
        
    }

    public void back()
    {
        BTNcanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void toggle(bool stat) 
    {
      Screen.fullScreen = stat;
    }
    public void setGraphics(int tier) 
    {
      QualitySettings.SetQualityLevel(tier);
    }
}
