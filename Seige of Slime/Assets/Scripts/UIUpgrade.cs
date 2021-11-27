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

    public GameObject uiButtonHEALTH;
    public GameObject uiButtonARMOR;
    public GameObject uiButtonRSTRHEALTH;
    public GameObject uiButtonRSTRARMOR;

    public GameObject statsPanelDefender;
    public GameObject statsPanelCastle;
    
    private void Start()
    {
        uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);
        
        uiButtonHEALTH.SetActive(false);
        uiButtonARMOR.SetActive(false);
        uiButtonRSTRHEALTH.SetActive(false);
        uiButtonRSTRARMOR.SetActive(false);
        
        statsPanelDefender.SetActive(false);
        statsPanelCastle.SetActive(false);
    }

    public void EnableButton()
    {
        uiButtonDPS.SetActive(true);
        uiButtonPPS.SetActive(true);
        uiButtonRANGE.SetActive(true);
        
        statsPanelDefender.SetActive(true);
    }

    public void EnableButtonCastle()
    {
        uiButtonHEALTH.SetActive(true);
        uiButtonARMOR.SetActive(true);
        uiButtonRSTRHEALTH.SetActive(true);
        uiButtonRSTRARMOR.SetActive(true);
        
        statsPanelCastle.SetActive(true);
    }

    public void DisableButton()
    {
        uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);
        
        statsPanelDefender.SetActive(false);
    }

    public void DisableButtonCastle()
    {
        uiButtonHEALTH.SetActive(false);
        uiButtonARMOR.SetActive(false);
        uiButtonRSTRHEALTH.SetActive(false);
        uiButtonRSTRARMOR.SetActive(false);
        
        statsPanelCastle.SetActive(false);
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
    
    public void UpgradeHEALTH()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<CastleManager>().UpgradeHealth();
        }
    }
    
    public void UpgradeARMOR()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<CastleManager>().UpgradeArmor();
        }
    }
    
    public void RestoreHEALTH()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<CastleManager>().Heal();
        }
    }
    
    public void RestoreARMOR()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<CastleManager>().Repair();
        }
    }
}
