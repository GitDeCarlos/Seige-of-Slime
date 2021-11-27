using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DefenderAi : MonoBehaviour
{
    private Vector3 projectileShootFromPosition;
    public GameObject rangeArea;
    public GameObject pfProjectileArrow;
    
    // Timer Stuff
    public float shootTimerMax = 0.01f;
    private float shootTimer;
    
    // Tower Stats
    public float range = 3.1f;
    public int damage = 5;

    private UIUpgrade uiUpgrade;
    private GameObject statsGroupObject;

    private void Start()
    {
        uiUpgrade = GameObject.Find("uButtons").GetComponent<UIUpgrade>();
        statsGroupObject = GameObject.Find("StatsPanel_Defender");
    }

    private void Update()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
        rangeArea.transform.localScale = new Vector3(range, range, 1);

        if (Input.GetMouseButtonDown(0))
        {
            /* if ()
            {
                rangeArea.GetComponent<SpriteRenderer>().enabled = true;
            }
            rangeArea.GetComponent<SpriteRenderer>().enabled = !rangeArea.GetComponent<SpriteRenderer>().isVisible;*/
        }
        
        if (shootTimer <= 0f)
        {
            shootTimer = shootTimerMax;
            
            AttackerAi attacker = GetClosestAttackerAi();
            if (attacker != null)
            {
                GameObject arrow = Instantiate(pfProjectileArrow, projectileShootFromPosition, quaternion.identity);
                arrow.GetComponent<ProjectileArrow>().damage = damage;
                arrow.GetComponent<ProjectileArrow>().Target(attacker);
            }
        }
        
        statsGroupObject.GetComponent<StatsPanel>().UpdateDefenderStats(damage, range, shootTimerMax);
        shootTimer -= Time.deltaTime;
    }

    public void UpgradeDPS()
    {
        damage = (int)(damage * 1.5);
    }

    public void UpgradePPS()
    {
        shootTimerMax *= 0.9f;
    }
    
    public void UpgradeRANGE()
    {
        range *= 1.2f;
    }
    
    private AttackerAi GetClosestAttackerAi()
    {
        AttackerAi attacker = GameObject.Find("GameManager").GetComponent<GameManager>().GetClosestAttackerAi(transform.position, range);
        return attacker;
    }

    public void Select()
    {
        uiUpgrade.EnableButton();
        
        rangeArea.GetComponent<SpriteRenderer>().enabled = true;
        uiUpgrade.SetUpgradeTarget(gameObject);
        // Show upgrade UI
    }

    public void Deselect()
    {
        uiUpgrade.DisableButton();
        
        rangeArea.GetComponent<SpriteRenderer>().enabled = false;
        uiUpgrade.ClearUpgradeTarget();
        // Hide upgrade UI
    }
}
