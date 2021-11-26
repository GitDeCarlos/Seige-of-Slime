using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIUpgrade : MonoBehaviour
{
    private GameObject upgradeTarget;

    public GameObject uiButtonDPS;
    public GameObject uiButtonPPS;
    public GameObject uiButtonRANGE;

    private void Start()
    {
        uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);
    }

    public void EnableButton()
    {
        uiButtonDPS.SetActive(true);
        uiButtonPPS.SetActive(true);
        uiButtonRANGE.SetActive(true);
    }

    public void DisableButton()
    {
        uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);
    }
    
    public void SetUpgradeTarget(GameObject target)
    {
        upgradeTarget = target;
    }

    public void ClearUpgradeTarget()
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
