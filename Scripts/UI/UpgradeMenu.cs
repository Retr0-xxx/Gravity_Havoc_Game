using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UpgradeList;

public class UpgradeMenu : MonoBehaviour, ISaveable
{
    public string[] BTNinfotmation;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public PlayerShoot playerShoot;
    public UpgradeList upgradeList = new UpgradeList();
    private int tankOrder = 1;
    private int tacticalOrder = 1;
    private int BTNnum = -1;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI warningMSG;
    public AudioSource unlockSound;
    public AudioSource FailunlockSound;
    public AudioSource selectSound;
    public GameObject[] tickSprite;
    bool[] tickValue;
    public string warningSrting;
   
    void Start()
    {
        upgradeList = new UpgradeList();
        tacticalOrder = 1;
         tankOrder = 1;
        //remove this to achieve saving
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerShoot = FindObjectOfType<PlayerShoot>();
        upgradeList.OnUnlocked += Upgradelist_OnUpgrade;
        setTick();
       
    }

    private void Update()
    {
      
    }
    private void Upgradelist_OnUpgrade(object sender,UpgradeList.onUnlockedArgs e)
    {
        switch (e.upgradeType) 
        {
            case UpgradeList.UpgradeType.health_I:
                set_Health_1();
                break;

            case UpgradeList.UpgradeType.speed_I:
                set_Speed_1();
                break;


            case UpgradeList.UpgradeType.health_II:
                set_Health_1();
                break;

            case UpgradeList.UpgradeType.speed_II:
                set_Speed_1();
                break;

            case UpgradeList.UpgradeType.SMG_mag:
                playerShoot.SMGMaxMag += 15;
                break;

            case UpgradeList.UpgradeType.shot_mag:
                playerShoot.ShotMaxMag += 4;
                break;

            case UpgradeList.UpgradeType.SMG_rate:
                playerShoot.SMG_rate = 20;
                break;

            case UpgradeList.UpgradeType.shot_rate:
                playerShoot.Shot_rate = 3;
                break;

            case UpgradeList.UpgradeType.dash:
                Dash.dashTime = 0.4f;
                break;

            case UpgradeList.UpgradeType.zoom:
                PlayerShoot.targetSMGFOV = 25f;
                break;
        }
        setTick();
    }
    public void Unlock()
    {
        switch (BTNnum)
        {
            case 1:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.health_I) == false && Check(10)==true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.health_I);
                    StartCoroutine(playWarningText("unlock sucessful"));
                    tankOrder += 1;
                }
                else 
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 2:
                if(upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.speed_I) == false && Check(10) == true) 
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.speed_I);
                    Debug.Log("speed_1 UNLOCKED"); 
                    tacticalOrder += 1;
                    StartCoroutine(playWarningText("unlock sucessful"));
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 3:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG) == false && tacticalOrder == 2 && Check(20) == true)
                {
                    unlockSound.Play();
                    Deduct(20);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.SMG);
                    Debug.Log("SMG UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                    tacticalOrder += 1;
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 4:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot) == false && tankOrder == 2 && Check(20) == true)
                {
                    unlockSound.Play();
                    Deduct(20);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.shot);
                    Debug.Log("shot UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                    tankOrder += 1;
                }
                else
                {
                    FailunlockSound.Play();
                    Debug.Log("fail to unlock: already unlocked or don't have enough Fe");
                }
                break;
            case 5:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG_rate) == false && tacticalOrder == 3 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.SMG_rate);
                    Debug.Log("SMG_rate UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 6:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot_rate) == false && tankOrder == 3 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.shot_rate);
                    Debug.Log("SMG_rate UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 7:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG_mag) == false && tacticalOrder == 3 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.SMG_mag);
                    Debug.Log("SMG_mag UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 8:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot_mag) == false && tankOrder == 3 && Check(10) == true) 
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.shot_mag);
                    Debug.Log("shot_mag UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 9:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.health_II) == false && tankOrder == 3 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.health_II);
                    Debug.Log("health_II UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                    tankOrder += 1;
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 10:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.speed_II) == false && tacticalOrder == 3 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.speed_II);
                    Debug.Log("speed_II UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                    tacticalOrder += 1;
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 11:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.dash) == false && tankOrder == 4 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.dash);
                    Debug.Log("dash UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));
                    
                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
            case 12:
                if (upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.zoom) == false && tacticalOrder == 4 && Check(10) == true)
                {
                    unlockSound.Play();
                    Deduct(10);
                    upgradeList.UnlockUpgrade(UpgradeList.UpgradeType.zoom);
                    Debug.Log("zoom UNLOCKED");
                    StartCoroutine(playWarningText("unlock sucessful"));

                }
                else
                {
                    FailunlockSound.Play();
                    StartCoroutine(playWarningText("fail to unlock: already unlocked or don't have enough Fe"));
                }
                break;
        }
    
    }

    bool Check(float price) 
    {
        if (Inventory.Fe >= price)
            return true;
        else
            return false;
    }

    void Deduct(float price) 
    {
      Inventory.Fe -= price;    

    }
    void setTick() 
    {
        tickValue = new bool[12];
        tickValue[0] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.health_I);
        tickValue[1] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.speed_I);
        tickValue[2] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG);
        tickValue[3] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot);
        tickValue[4] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG_rate);
        tickValue[5] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot_rate);
        tickValue[6] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.SMG_mag);
        tickValue[7] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.shot_mag);
        tickValue[8] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.health_II);
        tickValue[9] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.speed_II);
        tickValue[10] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.dash);
        tickValue[11] = upgradeList.IsUpgradeUnlocked(UpgradeList.UpgradeType.zoom);
        int count = 0;
        foreach (GameObject obj in tickSprite) 
        {
            if (tickValue[count] == true)
            {
                obj.SetActive(true);
            }
            else
            { obj.SetActive(false); }
            count++;

        }
    
    
    }

    IEnumerator playWarningText(string text) 
    {
        warningMSG.text = "";

        for (int i=0; i<text.Length; i++) 
        {
            warningMSG.text += text[i];
            yield return new WaitForSecondsRealtime(0.02f);
        }
        float TM = 2f;
        while (TM > 0)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            warningMSG.enabled = false;
            yield return new WaitForSecondsRealtime(0.3f);
            warningMSG.enabled = true;
            TM -= 0.6f;
        }

        warningMSG.text = "";
    }



    public void Press_BTN_num1()
    {
        BTNnum = 1;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num2()
    {
        BTNnum = 2;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num3()
    {
        BTNnum = 3;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num4()
    {
        BTNnum = 4;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num5()
    {
        BTNnum = 5;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num6()
    {
        BTNnum = 6;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num7()
    {
        BTNnum = 7;
        selectSound.Play();
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }
    public void Press_BTN_num8()
    {
        selectSound.Play(); 
        BTNnum = 8;
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }

    public void Press_BTN_num9()
    {
        selectSound.Play();
        BTNnum = 9;
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }

    public void Press_BTN_num10()
    {
        selectSound.Play();
        BTNnum = 10;
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }

    public void Press_BTN_num11()
    {
        selectSound.Play();
        BTNnum = 11;
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }

    public void Press_BTN_num12()
    {
        selectSound.Play();
        BTNnum = 12;
        textMeshProUGUI.text = BTNinfotmation[BTNnum - 1];
    }

    private void set_Health_1() 
    {
        playerHealth.maxHealth += 50;
    
    }

    private void set_Speed_1()
    {
        playerMovement.speed += 10;
    }

    public object CaptureState()
    {
        Debug.Log("list Captured");
        return new saveData
        {
            UnlockedUpgradeList = upgradeList.UnlockedUpgradeList,
            tacticalOrder = tacticalOrder,
            tankOrder = tankOrder,
        };

    }

    public void RestoreState(object state)
    {
        Debug.Log("list restored");
        var saveData = (saveData)state;
        upgradeList.UnlockedUpgradeList = saveData.UnlockedUpgradeList;
        tacticalOrder = saveData.tacticalOrder;
        tankOrder = saveData.tankOrder;
      
    }

    [Serializable]
    struct saveData
    {
        public List<UpgradeType> UnlockedUpgradeList;
        public int tacticalOrder;
        public int tankOrder;
    }


}
