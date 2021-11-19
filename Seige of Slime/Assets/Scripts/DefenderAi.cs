using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

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

    private void Awake()
    {
        projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
        //rangeArea = GameObject.Find("RangeArea");
    }

    private void Update()
    {
        
        GameObject rangeArea = GameObject.Find("RangeArea");
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
                arrow.GetComponent<ProjectileArrow>().Target(attacker);
            }
        }
        
        shootTimer -= Time.deltaTime;
    }

    private AttackerAi GetClosestAttackerAi()
    {
        AttackerAi attacker = GameObject.Find("GameManager").GetComponent<GameManager>().GetClosestAttackerAi(transform.position, range);
        return attacker;
    }

    public void Select()
    {
        rangeArea.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Deselect()
    {
        rangeArea.GetComponent<SpriteRenderer>().enabled = false;
    }
}
