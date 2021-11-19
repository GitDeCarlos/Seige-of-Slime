using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    private Vector3 targetPosition;
    private AttackerAi attacker;
    
    // Projectile stats
    public float moveSpeed = 10f;
    public int damage = 50;

    private void Update()
    {
        if (attacker == null)
        {
            Destroy(gameObject);
        }
        
        targetPosition = attacker.transform.position;
        Vector3 moveDir = (targetPosition - transform.position).normalized;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float destroySelfDistance = 0.1f;
        if (Vector3.Distance(transform.position, targetPosition) < destroySelfDistance)
        {
            attacker.Damage(damage);
            Destroy(gameObject);
        }
    }

    public void Target(AttackerAi attacker)
    {
        this.attacker = attacker;
    }
}
