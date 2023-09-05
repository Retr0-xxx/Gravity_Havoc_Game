using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;

public class TriggerDialougeText : MonoBehaviour
{
    public TextMeshProUGUI DialougeText;
    public GameObject ImageArt;
    public GameObject ImageHash;
    string[] textArray;
    string FinalTextArray;
    public  bool IsCon = false;

   
    public IEnumerator typeDialouge(string fileName)
    {
        IsCon = true;
        string filePath = Application.dataPath + "/allText/" + fileName;

        if (File.Exists(filePath))
        {
            DialougeText.text = "";

            textArray = File.ReadAllLines(filePath);

            FinalTextArray = string.Join("", textArray);

            foreach (char c in FinalTextArray)
            { 
                if (c == '$')
                {
                    yield return new WaitForSeconds(1f);
                    DialougeText.text = "";
                    continue;
                }
                if (c == '#') 
                {
                 ImageHash.SetActive(true);
                 ImageArt.SetActive(false);
                    continue;
                }
                if (c == '@')
                { 
                 ImageArt.SetActive(true);
                 ImageHash.SetActive(false);
                    continue;
                }

                DialougeText.text += c;
                yield return new WaitForSeconds(0.03f);
            }

        }
        yield return new WaitForSeconds(1f);
        ImageHash.SetActive(false);
        ImageArt.SetActive(false);
        DialougeText.text = "";
        IsCon = false;
    }
}
