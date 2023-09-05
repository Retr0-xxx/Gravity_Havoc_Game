using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class SaveAndLoad : MonoBehaviour
{
    public string savePath => $"{Application.persistentDataPath}/save.txt";

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
       
    }
    private void Awake()
    {
      
        load();
        PauseMenu.isPaused = false;
        PauseMenu.isMenuOut = false;

    }

    public void quit()
    {
        SceneManager.LoadScene(0);
    }

    [ContextMenu("do save")]
    public void save() 
    {
        var state = CaptureState();

        using (var stream = File.Open(savePath, FileMode.Create)) 
        {
           var formatter = new BinaryFormatter();
           formatter.Serialize(stream, state);
        }

        
    }
    [ContextMenu("do load")]
    public void load()
    {

        object state;
        
            using (var stream = File.Open(savePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                state = formatter.Deserialize(stream);
            }
        

        RestoreState(state);
    }

    public object CaptureState() 
    {
        var state = new Dictionary<string, object>();
        foreach (var saveable in FindObjectsOfType<SaveableObject>())
        {
            state[saveable.ID] = saveable.CaptureState();
        
        }

     
        return state;
    }
    public void RestoreState(object state) 
    {
        

        foreach (var saveable in FindObjectsOfType<SaveableObject>())
        {
            Debug.Log("code reached");

            var stateDictionary = (Dictionary<string, object>)state;

         

            if (stateDictionary.TryGetValue(saveable.ID, out object value))
            {
               
                saveable.RestoreState(value);
            }

        }


    }

}
