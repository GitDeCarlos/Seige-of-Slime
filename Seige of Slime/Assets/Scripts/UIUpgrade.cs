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

        uCastleGroup.SetActive(false);
    }

    public void EnableButton()
    {
        uDefendersGroup.SetActive(true);
        UpdateStatsDefender();
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
            UpdateStatsDefender();
        }
    }

    public void UpgradePPS()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<DefenderAi>().UpgradePPS();
            UpdateStatsDefender();
        }
    }
    
    public void UpgradeRANGE()
    {
        if (MoneyManager.TakeMoney(20))
        {
            upgradeTarget.GetComponent<DefenderAi>().UpgradeRANGE();
            UpdateStatsDefender();
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

    public void UpdateStatsDefender()
    {
        int tempDamage = upgradeTarget.GetComponent<DefenderAi>().GetDamage();
        float tempRange = upgradeTarget.GetComponent<DefenderAi>().GetRange();
        float tempFirerate = upgradeTarget.GetComponent<DefenderAi>().GetFirerate();
        //Debug.Log(tempDamage + ", " + tempRange + ", " + tempFirerate );
        
        statsPanelDefender.GetComponent<StatsPanel>().UpdateDefenderStats(tempDamage, tempRange, tempFirerate);
    }
}
