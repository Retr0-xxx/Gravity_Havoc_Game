using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Animations.Rigging;

using Random = UnityEngine.Random;

public class PlayerShoot : MonoBehaviour,ISaveable
{
    public Rigidbody PlayerRigidbody;
    public static bool isReloadDisabled = false;
    public GameObject PistolBullet;
    public GameObject SMGBullet;
    public GameObject ShotBullet;
    bool isOnePistolOn = false;
    bool isSMGOn = false;
    bool isShotOn = false;
    public float pistolMaxMag;
    public float pistolMag;
    public float SMGMaxMag;
    public float SMGMag;
    public float ShotMaxMag;
    public float ShotMag;
    public ParticleSystem pistolParticle;
    public ParticleSystem SMGParticle;
    public ParticleSystem ShotParticle;
    float timeElapsed;
    float weight;
    bool isReloadOn = false;
    public Rig IKconstraint;
    public CameraShake cameraShake;
    public int weaponNUM;
    public float pistolMaxAmmo;
    public float SMGMaxAmmo;
    public float ShotMaxAmmo;
    public float pistolAmmo;
    public float SMGAmmo;
    public float ShotAmmo;
    public float SMGRecoil;
    public float pistolRecoil;
    public float ShotRecoil;
    public GameObject bulletShell;
    public Transform shellOutlet;
    AudioSource audioSource;
    public AudioClip SMGsound;
    public AudioClip pistolsound;
    public AudioClip shotsound;
    public AudioClip reloadsound;
    public GameObject Muzzlelight;
    public UpgradeMenu upgradeMenu;
    public float SMG_rate = 1;
    public float Shot_rate = 1;
    public static float targetSMGFOV = 30f;
    public MultiAimConstraint WeaponAimConstrant;



    void Start()
    {
       
       /* SMGMag = SMGMaxMag;
        pistolMag = pistolMaxMag;
        pistolAmmo = 50f;
        SMGAmmo = 100f;
        ShotMag = ShotMaxMag;
        ShotAmmo = 25f;*/
        weight = 0f;
        weaponNUM = 1;
        audioSource = GetComponent<AudioSource>();
        upgradeMenu = FindObjectOfType<UpgradeMenu>();
        
    }

   
    void Update()
    {
        weaponSelection();

        if(weaponNUM == 1 )
           shootPistol();

        if (weaponNUM == 2)
            shootSMG();

        if (weaponNUM == 3)
            shootShot();
    }
    void weaponSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerAim.targetFOV = 27f;
            weaponNUM = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && upgradeMenu.upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG))
        {
            PlayerAim.targetFOV = targetSMGFOV;
            weaponNUM = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && upgradeMenu.upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot))
        {
            PlayerAim.targetFOV = 33f;
            weaponNUM = 3;
        }


    }

    void shootPistol() 
    {
        if (Input.GetMouseButtonDown(0) && pistolMag>0)
        {
            if (isOnePistolOn == false)
            {
                StartCoroutine(shootOnePistol());
                // cameraShake.ShakeCam(0.1f, 0.02f);
                 cameraShake.ShakeCam(0f, 0f);   
                pistolMag--;
            }
        }

        if (pistolMag <= 0 || Input.GetKeyDown(KeyCode.R)==true)
        {
            if(isReloadOn==false && pistolAmmo>0)
            StartCoroutine(reload());
        }
    
    }

    IEnumerator shootOnePistol() 
    {
        isOnePistolOn=true;
        StartCoroutine(AddBackForce(10f, 0.3f));
        PlayerAim.offsetREF += pistolRecoil;
        giveShell();
        pistolParticle.Play();
        Muzzlelight.SetActive(true);
        audioSource.PlayOneShot(pistolsound);
        GameObject launched = Instantiate(PistolBullet, transform.position, transform.rotation);
        launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 1000f));
        yield return new WaitForSeconds(0.1f);
        pistolParticle.Stop();
        Muzzlelight.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        isOnePistolOn = false;  
    }

    IEnumerator reload() 
    {
        isReloadOn=true;
        audioSource.PlayOneShot(reloadsound);

        if (isReloadDisabled == false) 
            {
                PlayerAim.aimLocked = true;
                timeElapsed = 0f;
                while (timeElapsed < 1.2f)
                {
                    weight = Mathf.Lerp(weight, 1f, Time.deltaTime * 3);
                    IKconstraint.weight = weight;
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                timeElapsed = 0f;
                while (timeElapsed < 0.8f)
                {
                    weight = Mathf.Lerp(weight, 0f, Time.deltaTime * 5);
                    IKconstraint.weight = weight;
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                timeElapsed = 0f;


                if (weaponNUM == 1)
                {
                    if (pistolAmmo < pistolMaxMag)
                    {
                    pistolMag = pistolAmmo;
                    pistolAmmo = 0;
                    }
                    else
                    {
                    pistolAmmo -= (pistolMaxMag - pistolMag);
                    pistolAmmo = Mathf.Max(pistolAmmo, 0);
                    pistolMag = pistolMaxMag;
                    }
                }
                if (weaponNUM == 2)
                {
                  if (SMGAmmo < SMGMaxMag)
                  {
                     SMGMag = SMGAmmo;
                     SMGAmmo = 0;
                  }
                  else
                  {
                    SMGAmmo -= (SMGMaxMag - SMGMag);
                    SMGAmmo = Mathf.Max(SMGAmmo, 0);
                    SMGMag = SMGMaxMag;
                  }
              
                }
                if (weaponNUM == 3)
                {
                  if (ShotAmmo < ShotMaxMag)
                  {
                    ShotMag = ShotAmmo;
                    ShotAmmo = 0;
                  }
                  else
                  {
                    ShotAmmo -= (ShotMaxMag - ShotMag);
                    ShotAmmo = Mathf.Max(ShotAmmo, 0);
                    ShotMag = ShotMaxMag;
                  }
                }
                PlayerAim.aimLocked = false;
            }

        isReloadOn = false;
    }

    void shootSMG() 
    {
        if (Input.GetMouseButton(0) && SMGMag > 0)
        {
            if (isSMGOn == false)
            {
                Debug.Log("oneBullet");
                StartCoroutine(shootOneSMG());
                // cameraShake.ShakeCam(0.03f, 0.015f);
                cameraShake.ShakeCam(0f, 0f);
                SMGMag--;
            }
        }

        if (SMGMag <= 0 || Input.GetKeyDown(KeyCode.R) == true)
        {
            if (isReloadOn == false && SMGAmmo>0)
                StartCoroutine(reload());
        }

    }

    IEnumerator shootOneSMG()
    {
       
        isSMGOn = true;
        StartCoroutine(AddBackForce(5f, 0.3f));
        PlayerAim.offsetREF += SMGRecoil;
        SMGParticle.Play();
        Muzzlelight.SetActive(true);
        giveShell();
        audioSource.PlayOneShot(SMGsound);
        GameObject launched = Instantiate(SMGBullet, transform.position, transform.rotation);
        launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-10, 10), 0, 1000f));
        yield return new WaitForSeconds(0.05f);
        Muzzlelight.SetActive(false);
        SMGParticle.Stop();
        yield return new WaitForSeconds(0.05f*(1 / SMG_rate));
        isSMGOn = false;
    }

    void shootShot()
    {
        if (Input.GetMouseButtonDown(0) && ShotMag > 0)
        {
            if (isShotOn == false)
            {
                StartCoroutine(shootOneShot());
                cameraShake.ShakeCam(0.1f, 0.04f);
                ShotMag--;
            }
        }

        if (ShotMag <= 0 || Input.GetKeyDown(KeyCode.R) == true)
        {
            if (isReloadOn == false && ShotAmmo>0)
                StartCoroutine(reload());
        }

    }

    IEnumerator shootOneShot()
    {
        isShotOn = true;
        StartCoroutine(AddBackForce(10f, 0.3f));
        PlayerAim.offsetREF += ShotRecoil;
        ShotParticle.Play();
        Muzzlelight.SetActive(true);
        giveShell();
        audioSource.PlayOneShot(shotsound);
        for (int i = 0; i < 20; i++)
        {
            GameObject launched = Instantiate(ShotBullet, transform.position + new Vector3(0,Random.value/2,0), transform.rotation);
            launched.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), 500f));
        }
        yield return new WaitForSeconds(0.1f);
        Muzzlelight.SetActive(false);
        ShotParticle.Stop();
        yield return new WaitForSeconds(0.6f*(1/Shot_rate));
        isShotOn = false;
    }

    IEnumerator AddBackForce(float intensity, float duration) 
    {
        PlayerRigidbody.AddForce(transform.TransformDirection(-Vector3.forward*intensity));
        yield return new WaitForSeconds(duration);
     /*  while (WeaponAimConstrant.data.offset.y > -9.8f)
        {
            WeaponAimConstrant.data.offset = Vector3.Lerp(WeaponAimConstrant.data.offset, new Vector3(0, -5, 0),Time.deltaTime*20);
            yield return new  WaitForFixedUpdate();

        }
        while (WeaponAimConstrant.data.offset.y < -0.2f)
        {
            WeaponAimConstrant.data.offset = Vector3.Lerp(WeaponAimConstrant.data.offset, new Vector3(0, 0, 0), Time.deltaTime *20);
            yield return new WaitForFixedUpdate();
            WeaponAimConstrant.data.offset = Vector3.zero;
        }*/
    }

    void giveShell() 
    {
        GameObject Shell = Instantiate(bulletShell,shellOutlet.position, shellOutlet.rotation);
        Shell.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Random.Range(20f, 50f), Random.Range(20f, 50f), Random.Range(100f, 200f)));
        Shell.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(Random.Range(0,1f),0,0));
        Destroy(Shell,6f);
    }

    

    public object CaptureState()
    {
        return new saveData
        {
            pistolMaxMag = pistolMaxMag,
            pistolMag = pistolMag,
            SMGMaxMag = SMGMaxMag,
            SMGMag = SMGMag,
            ShotMaxMag = ShotMaxMag,
            ShotMag = ShotMag,
            pistolMaxAmmo = pistolMaxAmmo,
            SMGMaxAmmo = SMGMaxAmmo,
            ShotMaxAmmo = ShotMaxAmmo,
            pistolAmmo = pistolAmmo,
            SMGAmmo = SMGAmmo,
            ShotAmmo = ShotAmmo,
            SMG_rate = SMG_rate,
            Shot_rate = Shot_rate,
            targetSMGFOV = targetSMGFOV,
        };

    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        pistolMaxMag = saveData.pistolMaxMag;
        pistolMag = saveData.pistolMag;
        SMGMaxMag = saveData.SMGMaxMag;
        SMGMag = saveData.SMGMag;
        ShotMaxMag = saveData.ShotMaxMag;
        ShotMag = saveData.ShotMag;
        pistolMaxAmmo = saveData.pistolMaxAmmo;
        SMGMaxAmmo = saveData.SMGMaxAmmo;
        ShotMaxAmmo = saveData.ShotMaxAmmo;
        pistolAmmo = saveData.pistolAmmo;
        SMGAmmo = saveData.SMGAmmo;
        ShotAmmo = saveData.ShotAmmo;
        SMG_rate = saveData.SMG_rate;
        Shot_rate = saveData.Shot_rate;
        targetSMGFOV = saveData.targetSMGFOV;
       
    }

    [Serializable]
    struct saveData
    {
        public float pistolMaxMag;
        public float pistolMag;
        public float SMGMaxMag;
        public float SMGMag;
        public float ShotMaxMag;
        public float ShotMag;
        public float pistolMaxAmmo;
        public float SMGMaxAmmo;
        public float ShotMaxAmmo;
        public float pistolAmmo;
        public float SMGAmmo;
        public float ShotAmmo;
        public float SMG_rate;
        public float Shot_rate;
        public float targetSMGFOV;
    }

}
