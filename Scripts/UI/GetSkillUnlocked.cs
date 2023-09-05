using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSkillUnlocked : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public UpgradeMenu upgradeMenu;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        upgradeMenu = FindObjectOfType<UpgradeMenu>(); 
    }

    void Update()
    {
        int count = upgradeMenu.upgradeList.UnlockedUpgradeList.Count;
        textMeshPro.text = count.ToString() + "/12";
    }
}
