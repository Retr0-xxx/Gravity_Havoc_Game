using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class STATbar : MonoBehaviour
{
    public Slider slider;
    public Slider oxgenSilder;
    public PlayerHealth playerHealth;
    public Oxygen Oxygen;
    public float targetHealth;
    public float targetOxy;

    public PlayerShoot playerShoot;
    public TextMeshProUGUI text;
 
    public Image Pistol;
    public Image Assult;
    public Image Shot;

    public Image hurtEffect;

    public GameObject HurtRotate;

    public GameObject dashReady;

  
    Image hurtDir;

   public static float transprancy = 0f;

    private void Start()
    {
      
        SetMaxHealth(playerHealth.maxHealth);
        SetMaxOxy(Oxygen.maxOxygen);
        targetOxy = 0f;
        targetHealth = 0f;
        hurtDir = HurtRotate.GetComponent<Image>();
    }

    private void Update()
    {
        targetOxy = Mathf.Lerp(targetOxy, Oxygen.oxgen, Time.unscaledDeltaTime * 4);
        targetHealth = Mathf.Lerp(targetHealth, playerHealth.health, Time.unscaledDeltaTime*4);
        SetHealth(targetHealth);
        SetOxy(targetOxy);

        if (playerShoot.weaponNUM == 1)
        {
            Assult.enabled = false;
            Pistol.enabled = true;
            Shot.enabled = false;
            text.text = playerShoot.pistolMag.ToString() + " / " + playerShoot.pistolAmmo.ToString();
        }


        if (playerShoot.weaponNUM == 2)
        {
            Assult.enabled = true;
            Pistol.enabled = false;
            Shot.enabled = false;
            text.text = playerShoot.SMGMag.ToString() + " / " + playerShoot.SMGAmmo.ToString();

        }
        if (playerShoot.weaponNUM == 3)
        {
            Assult.enabled = false;
            Pistol.enabled = false;
            Shot.enabled = true;
            text.text = playerShoot.ShotMag.ToString() + " / " + playerShoot.ShotAmmo.ToString();

        }

        if (Dash.isCon == false)
        {
            dashReady.SetActive(true);
        }
        else
        {
            dashReady.SetActive(false);
        }


        fadeAway();

        Vector3 currentRot = transform.eulerAngles;

       HurtRotate.transform.eulerAngles = new Vector3(currentRot.x,currentRot.y, CheckCollsionAngle.rotation);

       
        
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

       

    }

    public void SetHealth(float health)
    {
        slider.value = health;

        
    }

    public void SetMaxOxy(float oxy)
    {
        oxgenSilder.maxValue = oxy;
        oxgenSilder.value = oxy;



    }

    public void SetOxy(float oxy)
    {
        oxgenSilder.value = oxy;


    }



    void fadeAway() 
    {
        transprancy = Mathf.Lerp(transprancy, 0f, Time.deltaTime*3f);

        if (transprancy != 0f)
        {
            Color newColor1 = hurtDir.color;
            Color newColor2 = hurtEffect.color;
            newColor1.a = transprancy;
            newColor2.a = transprancy;
            hurtEffect.color = newColor2;
            hurtDir.color = newColor1;

        }
        
    }

    IEnumerator Hurtdirection() 
    {
        HurtRotate.SetActive(true);
       // HurtRotate.transform.rotation = CheckCollsionAngle.rotation;
        yield return new WaitForSeconds(1f);
        HurtRotate.SetActive(false);

    }
    
}
