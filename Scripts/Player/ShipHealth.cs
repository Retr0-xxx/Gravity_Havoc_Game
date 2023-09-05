using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    bool isCon=false;
    float shipHealth;
    float targetHealth;
    public float shipMaxHealth;
    public float bulletDMG;
    public Slider slider;
    public Image hurtScreem;
    public AudioSource hitAudio;
    public GameObject blackScreen;
    public GameObject audios;
    Color cr;
    void Start()
    {
        targetHealth = shipMaxHealth;
        shipHealth = shipMaxHealth;
        setMaxHealth();
        cr = hurtScreem.color;
    }

 
    void Update()
    {
        shipHealth = Mathf.Lerp(shipHealth, targetHealth, Time.deltaTime * 4f);
        setHealth();
        cr.a = Mathf.Lerp(cr.a, 0, Time.deltaTime*4f);
        hurtScreem.color = cr;

        if (shipHealth <= 0 && isCon == false) 
        {
            StartCoroutine(die());
        }

    }

    private void setHealth()
    {
        slider.value = shipHealth;
    }

    private void setMaxHealth()
    {  
        slider.maxValue = shipMaxHealth;
        slider.value = shipMaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PistolBullet")) 
        {
            targetHealth -= bulletDMG;
            cr.a = 0.5f;
            hitAudio.Play();
        }
    }

    IEnumerator die() 
    {
        isCon = true;
        blackScreen.SetActive(true);
        audios.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(3);
        

    
    }
}
