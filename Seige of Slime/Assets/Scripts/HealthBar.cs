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
        //bar.localScale = new Vector3(.5f, 1f);
    }

    public void SetHealth(int health)
    {
        this.totalHealth = health;
    }
    
    public void UpdateHealth(int health)
    {
        float ratio = (float)health / (float)totalHealth;
        bar.localScale = new Vector3(ratio, 1f);
    }

    public void UpdateBar(int newHealth, int oldHealth)
    {
        
    }
}
