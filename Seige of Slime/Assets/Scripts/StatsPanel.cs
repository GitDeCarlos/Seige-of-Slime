using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsPanel : MonoBehaviour
{
    public GameObject statsObject;
    public bool isDefender;

    private int health = 0;
    private int maxHealth = 0;
    private int armor = 0;
    private int maxArmor = 0;

    private int damage = 0;
    private float range = 0f;
    private float firerate = 0f;

    private string statsText = "";
    private void Update()
    {
        if (isDefender)
        {
            statsText = damage + "\n" + firerate +"\n" + range;
        }
        else
        {
            statsText = armor + "/" + maxArmor +"\n" + health + "/" + maxHealth;
        }
        statsObject.GetComponent<TextMeshProUGUI>().text = statsText;
    }

    public void UpdateDefenderStats(int damage, float range, float firerate)
    {
        this.damage = damage;
        this.range = range;
        this.firerate = firerate;
    }

    public void UpdateCastleStats(int health, int maxHealth, int armor, int maxArmor)
    {
        this.health = health;
        this.maxHealth = maxHealth;
        this.armor = armor;
        this.maxArmor = maxArmor;
    }
}
