using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class healthCenter : MonoBehaviour
{
    public AudioSource healAudio;
    public AudioSource failHealAudio;
    public GameObject Icon;
    PlayerHealth playerHealth;
    public TextMeshProUGUI text;
    Oxygen oxygen;
    float LastUseTime;
    bool isCon = false;
    Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        oxygen = FindObjectOfType<Oxygen>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        LastUseTime = Time.time-30f;
    }

    void Update()
    {
        Icon.transform.RotateAround(Icon.transform.position, Vector3.up, Time.deltaTime * 20f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            outline.enabled = true;
            if ((Time.time - LastUseTime) > 30f)
            {
                oxygen.oxgen = oxygen.maxOxygen;
                playerHealth.health = playerHealth.maxHealth;
                LastUseTime = Time.time;
                text.text = "Vital Sign Stablized";
                healAudio.Play();
            }
            else
            {    
                text.text = "Recharging..."+ (30f-(Time.time - LastUseTime)).ToString("F1");
                failHealAudio.Play();
            }

            if (text.text != "") 
            {
                if (isCon == false)
                {
                    StartCoroutine(CloseWindow());
                }
            }
        }


        IEnumerator CloseWindow()
        {
            isCon = true;
            for (int i = 0; i < 3; i++)
            {
                text.enabled = false;
                yield return new WaitForSeconds(0.5f);
                text.enabled = true;
                yield return new WaitForSeconds(0.5f);
            }
            text.text = "";
            isCon = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
            outline.enabled = false;
    }
}
