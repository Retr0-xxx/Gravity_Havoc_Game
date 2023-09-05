using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
   public GameObject blackScreen;
    public GameObject BTNcanvas;
    public GameObject SettingCanvas;

   
    public void newGame() 
    {
        blackScreen.SetActive(true);
        deleteData();
        SceneManager.LoadSceneAsync(1);
       
    }

    public void resumeGame()
    {
        blackScreen.SetActive(true);
        SceneManager.LoadSceneAsync(2);
    }

    void deleteData() 
    {
       

        string[] filePaths = Directory.GetFiles(Application.persistentDataPath);
        foreach (string filePath in filePaths)
        {
            if (filePath == "save.txt")
            {
                File.Delete(filePath);
                Debug.Log("fileDeleted");
            }
        }
    }

    public void Settings()
    {
        BTNcanvas.SetActive(false);
        SettingCanvas.SetActive(true);
    }
}
