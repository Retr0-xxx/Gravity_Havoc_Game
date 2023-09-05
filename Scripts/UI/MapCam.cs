using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCam : MonoBehaviour
{
    public GameObject nameCanvas;
    public PlayerShoot playerShoot;
    public PlayerMovement playerMovement;
    public GameObject[] setFalses;
    public GameObject Cam;
    public Transform MapPos;
    public Transform Player;
    bool mapOut = false;
    bool isCon = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)&&!isCon) 
        {
            mapOut = !mapOut;

            if (mapOut) 
            {            
                StartCoroutine(moveCam());
            }
            if (!mapOut) 
            {
                StartCoroutine (moveCamBack());
            }
        }

        
       
      
    }

    private void setFalse(bool stat)
    {
        foreach (GameObject obj in setFalses) 
        {
          obj.SetActive(stat);
        }
        playerShoot.enabled = stat;
        playerMovement.enabled = stat;
    }

    IEnumerator moveCam() 
    {
        isCon = true;
        nameCanvas.SetActive(true);
        Cam.SetActive(true);
        setFalse(false);
        Cam.transform.position = Player.position;
        Cam.transform.rotation = Player.rotation;

        while ((Cam.transform.position - MapPos.position).magnitude>1f) 
        {
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, MapPos.position, Time.deltaTime*3);
            Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation, MapPos.rotation, Time.deltaTime*3);
            yield return new WaitForEndOfFrame();
        }
        isCon = false;
        Debug.Log("moveFinished");

    }
    IEnumerator moveCamBack()
    {
        
        isCon = true;
        Debug.Log("moveBack");
        while ((Cam.transform.position - Player.position).magnitude>1f)
        {
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Player.position, Time.deltaTime * 5);
            Cam.transform.rotation = Quaternion.Lerp(Cam.transform.rotation,Player.rotation, Time.deltaTime*5);
            yield return new WaitForEndOfFrame();
        }
        setFalse(true);
        Cam.SetActive(false);
        nameCanvas.SetActive(false);
        isCon = false;

    }

}
