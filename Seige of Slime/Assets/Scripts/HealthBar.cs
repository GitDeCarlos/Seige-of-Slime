using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    public int totalHealth;

    private void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetHealth(int health)
    {
        totalHealth = health;
    }
    
    public void UpdateHealth(int health)
    {
        if (health < 0)
        {
            bar.localScale = new Vector3(0f, 1f);
            return;
        }
        float ratio = (float)health / (float)totalHealth;
        bar.localScale = new Vector3(ratio, 1f);
    }
}
