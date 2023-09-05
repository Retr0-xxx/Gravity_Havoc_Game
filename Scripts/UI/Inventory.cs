
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour,ISaveable
{
    public static float Fe;
    public static float Pb;
    public static float O;
    public static float N;
    public static float Au;
    public static float healthSyringe;
    public static float oxygenTank;

    public GameObject inventoryShow;

    public static bool stat = false;

    public TextMeshProUGUI textFe;
    public TextMeshProUGUI textPb;
    public TextMeshProUGUI textO;
    public TextMeshProUGUI textN;
    public TextMeshProUGUI textAu;
    public TextMeshProUGUI syringe;
    public TextMeshProUGUI tanks;
    public TextMeshProUGUI pistol;
    public TextMeshProUGUI SMG;
    public TextMeshProUGUI Shot;

    public PlayerShoot playerShoot;

    float checkFe;
    float checkPb;
    float checkO;
    float checkN;
    float checkAu;
    float checkhealthSyringe;
    float checkoxygenTank;

    public TextMeshProUGUI changeDisplay;

    string disp;

    public Transform inventoryMenu;

    public AudioSource pauseSound;
    public AudioSource craftSound;

    private void Start()
    {
     Fe=0;
     Pb=0;
     O = 0;
     N = 0;
     Au = 0;
     healthSyringe = 0;
     oxygenTank = 0;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pauseSound.Play();
            stat = !stat;
            if (PauseMenu.isMenuOut == false)
            {
                PauseMenu.isPaused = stat;
            }
           inventoryShow.SetActive(stat);

            if (stat == true) 
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (stat == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }


        }

        if (stat == true) 
        {
            mouseMoveInventory();
            textFe.text = Fe.ToString();
            textPb.text = Pb.ToString();
            textO.text = O.ToString();
            textN.text = N.ToString();
            textAu.text = Au.ToString();

        }

        CheckFe();
        CheckPb();
        CheckO();
        CheckN();
        CheckAu();
        CheckHS();
        CheckOT();

        syringe.text = healthSyringe.ToString();
        tanks.text = oxygenTank.ToString();

        pistol.text = playerShoot.pistolAmmo.ToString();
        SMG.text = playerShoot.SMGAmmo.ToString();
        Shot.text = playerShoot.ShotAmmo.ToString();
    }

  
    public void PlusHS() 
    {
        if (N > 0 && Fe > 0)
        {
            N -= 1;
            Fe -= 1;
            healthSyringe++;
            craftSound.Play();
        }
    }

    public void PlusOT()
    {
        if (O > 0 && Fe > 0)
        {
            O -= 1;
            Fe -= 1;
            oxygenTank++;
            craftSound.Play();
        }
    }

    public void PlusPistol()
    {
        if (Fe > 0 )
        {
            Fe -= 1;         
            playerShoot.pistolAmmo += 15;
            craftSound.Play();
        }
    }

    public void PlusSMG()
    {
        if (Fe > 0 && Pb > 0)
        {
            Fe -= 1;
            Pb -= 1;
            playerShoot.SMGAmmo += 30;
            craftSound.Play();
        }
    }

    public void PlusShot()
    {
        if (Fe > 0 && Au > 0)
        {
            Fe -= 1;
            Au -= 1;
            playerShoot.ShotAmmo += 5;
            craftSound.Play();
        }
    }
    void CheckFe()
    {
        if (checkFe != Fe) 
        {
            
            float diff = (Fe - checkFe);
            checkFe = Fe;
            if (diff > 0)
            disp = "Fe +" + diff.ToString();
            else
            disp = "Fe " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }

    void CheckPb()
    {
        if (checkPb != Pb)
        {
            float diff = (Pb - checkPb);
            checkPb = Pb;
            if (diff > 0)
                disp = "Pb +" + diff.ToString();
            else
                disp = "Pb " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }

    void CheckO()
    {
        if (checkO != O)
        {
            float diff = (O - checkO);
            checkO = O;
            if (diff > 0)
                disp = "O +" + diff.ToString();
            else
                disp = "O " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }
    void CheckN()
    {
        if (checkN != N)
        {
            float diff = (N - checkN);
            checkN = N;
            if (diff > 0)
                disp = "N +" + diff.ToString();
            else
                disp = "N " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }

    void CheckHS()
    {
        if (checkhealthSyringe != healthSyringe)
        {
            float diff = (healthSyringe - checkhealthSyringe);
            checkhealthSyringe = healthSyringe;
            if (diff > 0)
                disp = "Health Syringe +" + diff.ToString();
            else
                disp = "Health Syringe " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }

    void CheckOT()
    {
        if (checkoxygenTank != oxygenTank)
        {
            float diff = (oxygenTank - checkoxygenTank);
            checkoxygenTank = oxygenTank;
            if (diff > 0)
                disp = "Oxygen Tank +" + diff.ToString();
            else
                disp = "Oxygen Tank " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }
    void CheckAu()
    {
        if (checkAu != Au)
        {
            float diff = (Au - checkAu);
            checkAu = Au;
            if (diff > 0)
                disp = "Au +" + diff.ToString();
            else
                disp = "Au " + diff.ToString();
            StartCoroutine(ChangeDisplay(disp));
        }
    }
    IEnumerator ChangeDisplay(string display) 
    {
        changeDisplay.enabled = true;
        changeDisplay.text += (display+'\n');
        yield return new WaitForSeconds(2f);
        changeDisplay.text = null;
        changeDisplay.enabled = false;
    
    
    
    }

    void mouseMoveInventory() 
    {

        Vector3 mousePos = Input.mousePosition;

        float rotY = ((mousePos.x) / (Screen.width / 2))*5 ;

        float rotX = ((mousePos.y - Screen.height / 2) / (Screen.height / 2))*5;

        inventoryMenu.localEulerAngles = new Vector3(rotX, rotY, 0);
       
    }

    public object CaptureState() 
    {
        return new saveData
        {
            Fe = Fe,
            Pb = Pb,
            O = O,
            N = N,
            Au = Au,
            healthSyringe = healthSyringe,
            oxygenTank = oxygenTank,

        };
    
    }

    public void RestoreState(object state)
    {
        var saveData = (saveData)state;
        Fe = saveData.Fe;
        Pb = saveData.Pb;
        O = saveData.O;
        N = saveData.N;
        Au = saveData.Au;
        healthSyringe = saveData.healthSyringe;
        oxygenTank = saveData.oxygenTank;
    }

    [Serializable] struct saveData
    {
        public float Fe;
        public float Pb;
        public float O;
        public float N;
        public float Au;
        public float healthSyringe;
        public float oxygenTank;
    }


    
}
