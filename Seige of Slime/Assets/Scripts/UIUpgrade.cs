using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIUpgrade : MonoBehaviour
{
    static GameObject upgradeTarget;
    
    static GameObject uiButtonDPS;
    static GameObject uiButtonPPS;
    static GameObject uiButtonRANGE;

    private void Start()
    {
        uiButtonDPS = GameObject.Find("uDPSButton");
        uiButtonDPS.SetActive(false);
        uiButtonPPS = GameObject.Find("uPPSButton");
        uiButtonPPS.SetActive(false);
        uiButtonRANGE = GameObject.Find("uRANGEButton");
        uiButtonRANGE.SetActive(false);
    }

    public static void EnableButton()
    {
        uiButtonDPS.SetActive(true);
        uiButtonPPS.SetActive(true);
        uiButtonRANGE.SetActive(true);
    }

    public static void DisableButton()
    {
        uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);
    }
    
    public static void SetUpgradeTarget(GameObject target)
    {
        upgradeTarget = target;
    }

    public static void ClearUpgradeTarget()
    {
        upgradeTarget = null;
    }

    public void UpgradeDPS()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<DefenderAi>().UpgradeDPS();
        }
    }

    public void UpgradePPS()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<DefenderAi>().UpgradePPS();
        }
    }
    
    public void UpgradeRANGE()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<DefenderAi>().UpgradeRANGE();
        }
    }
}
