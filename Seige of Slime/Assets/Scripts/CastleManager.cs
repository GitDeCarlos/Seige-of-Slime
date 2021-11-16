using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleManager : MonoBehaviour
{
    public HealthBar healthBar;
    private int health = 100;

    public HealthBar armorBar;
    private int armor = 100;

    public void Start()
    {
        healthBar = transform.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetHealth(health);

        armorBar = transform.Find("ArmorBar").GetComponent<HealthBar>();
        armorBar.SetHealth(armor);
    }

    public void Update()
    {
        armorBar.UpdateHealth(armor);
        healthBar.UpdateHealth(health);
        if (health < 1)
        {
            Debug.Log("----GAME OVER----");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.name)
        {
            case "SlimsterG(Clone)": 
                damage(other.GetComponent<AttackerAi>().damage);
                Destroy(other.gameObject);
                break;
        }
    }

    public void damage(int d)
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
}
