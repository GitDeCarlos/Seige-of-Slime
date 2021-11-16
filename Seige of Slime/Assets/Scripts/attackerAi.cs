using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class attackerAi : MonoBehaviour
{
    // Holds info for where to move to next
    public GameObject nextNode;
    public bool followingNode = true;
    
    // Attacker's stats
    public int health = 100;
    public int damage = 20;
    public float speedMod = 1.0f;
    public float velocity = 0.1f;
    
    private void Start()
    {
        nextNode = FindObjectOfType<pathNode>().gameObject;
        
    }

    void Update()
    {
        if (!followingNode)
        {
            return;
        }

        float direction;

        Vector3 newPosition;
        if (nextNode.GetComponent<pathNode>().align)
        {
            // Direction
            direction = (nextNode.transform.position.y > transform.position.y)? 1.0f : -1.0f;
            
            newPosition = new Vector3(nextNode.transform.position.x, transform.position.y + (velocity * speedMod * direction * Time.deltaTime), 0);
        }
        else
        {
            direction = (nextNode.transform.position.x > transform.position.x) ? 1.0f : -1.0f;
            newPosition = new Vector3(transform.position.x  + (velocity * speedMod * direction * Time.deltaTime), nextNode.transform.position.y, 0);
        }
        
        this.transform.position = newPosition;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (String.Compare(other.name, "Target Node") == 0)
        {
            if (nextNode.GetComponent<pathNode>().tailNode)
            {
                followingNode = false;
                return;
            }
            UpdateNode();
        }
    }

    void UpdateNode()
    {
        this.nextNode = nextNode.gameObject.GetComponent<pathNode>().nextNode;
    }
}
