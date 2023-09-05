using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackScreen : MonoBehaviour
{
    public AudioSource crash;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blackScreen());
    }

    IEnumerator blackScreen() 
    {
        crash.Play();
        AudioSource[] au = GameObject.FindWithTag("Player").GetComponentsInChildren<AudioSource>();
        foreach (AudioSource au2 in au) 
        { 
          au2.enabled = false;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
