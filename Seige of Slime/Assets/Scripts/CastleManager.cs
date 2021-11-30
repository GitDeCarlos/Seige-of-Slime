using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    private GameObject gameManager;
    
    public HealthBar healthBar;
    public int maxHealth = 100;
    private int health;
    private bool alive;

    public HealthBar armorBar;
    public int maxArmor = 100;
    private int armor;

    private UIUpgrade uiUpgrade;
    public GameObject rangeArea;

    private GameObject statsGroupObject;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager");
        uiUpgrade = GameObject.Find("uButtons").GetComponent<UIUpgrade>();
        
        healthBar.SetHealth(maxHealth);
        armorBar.SetHealth(maxArmor);

        health = maxHealth;
        armor = maxArmor;
        
        statsGroupObject = GameObject.Find("StatsPanel_Castle");
        alive = true;
    }

    public void Update()
    {
        armorBar.UpdateHealth(armor);
        healthBar.UpdateHealth(health);
        if (health < 1 && alive)
        {
            gameManager.GetComponent<GameManager>().GameOver(0);
            alive = false;
        }
        
        statsGroupObject.GetComponent<StatsPanel>().UpdateCastleStats(health, maxHealth, armor, maxArmor);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<AttackerAi>() != null)
        {
            this.Damage(other.GetComponent<AttackerAi>().damage);
            other.gameObject.GetComponent<AttackerAi>().Kill();
        }
    }

    public void UpgradeHealth()
    {
        maxHealth += 25;
        healthBar.SetHealth(maxHealth); Debug.Log(maxHealth);
    }

    public void Heal()
    {
        health = maxHealth;
    }

    public void UpgradeArmor()
    {
        maxArmor = maxArmor + (int)(0.25*maxArmor); Debug.Log(maxArmor);
        armorBar.SetHealth(maxArmor);
    }
    
    public void Repair()
    {
        armor = maxArmor;
    }

    public void Damage(int d)
    {
        if (armor > 0)
        {
            armor -= d;
        }
        else
        {
            health -= d;
        }
    }

    public void Select()
    {
        uiUpgrade.EnableButtonCastle();

        rangeArea.GetComponent<SpriteRenderer>().enabled = true;
        uiUpgrade.SetUpgradeTarget(gameObject);
    }

    public void Deselect()
    {
        uiUpgrade.DisableButtonCastle();
        
        rangeArea.GetComponent<SpriteRenderer>().enabled = false;
        uiUpgrade.ClearUpgradeTarget();
    }
}
