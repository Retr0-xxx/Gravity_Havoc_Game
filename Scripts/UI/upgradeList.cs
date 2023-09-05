using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class UpgradeList
{
    public event EventHandler<onUnlockedArgs> OnUnlocked;
    public class onUnlockedArgs: EventArgs { public UpgradeType upgradeType; }
    public enum UpgradeType
    {
        health_I,
        speed_I,
        shot,
        SMG,
        shot_rate,
        shot_mag,
        SMG_rate,
        SMG_mag,
        health_II,
        speed_II,
        dash,
        zoom,
    }

    public List<UpgradeType> UnlockedUpgradeList = new List<UpgradeType>();

    public void UnlockUpgrade(UpgradeType upgradeType) 
    {
      UnlockedUpgradeList.Add(upgradeType);
      OnUnlocked?.Invoke(this, new onUnlockedArgs { upgradeType = upgradeType });
    }

    public bool IsUpgradeUnlocked(UpgradeType upgradeType) 
    {
        return UnlockedUpgradeList.Contains(upgradeType); 
    }

}
