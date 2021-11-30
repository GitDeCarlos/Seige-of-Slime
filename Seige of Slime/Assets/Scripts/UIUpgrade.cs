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

    public GameObject uDefendersGroup;
    public GameObject uCastleGroup;
    
    private void Start()
    {
        uDefendersGroup.SetActive(false);
        /*uiButtonDPS.SetActive(false);
        uiButtonPPS.SetActive(false);
        uiButtonRANGE.SetActive(false);*/

        uCastleGroup.SetActive(false);
        /*uiButtonHEALTH.SetActive(false);
        uiButtonARMOR.SetActive(false);
        uiButtonRSTRHEALTH.SetActive(false);
        uiButtonRSTRARMOR.SetActive(false);*/
        
        //statsPanelDefender.SetActive(false);
        //statsPanelCastle.SetActive(false);
    }

    public void EnableButton()
    {
        uDefendersGroup.SetActive(true);
        //statsPanelDefender.GetComponent<StatsPanel>().UpdateDefenderStats(upgradeTarget);
    }

    public void EnableButtonCastle()
    {
        uCastleGroup.SetActive(true);
    }

    public void DisableButton()
    {
        uDefendersGroup.SetActive(false);
    }

    public void DisableButtonCastle()
    {
        uCastleGroup.SetActive(false);
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
