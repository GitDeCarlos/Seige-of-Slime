using System;
using UnityEngine;

public class AttackerAi : MonoBehaviour
{
    // Holds info for where to move to next
    public GameObject nextNode;
    public int nodeIndex = 1;
    public bool followingNode = true;
    
    // Attacker's stats
    public int health = 100;
    public int damage = 20;
    public float speedMod = 1.0f;
    public float velocity = 0.1f;
    public bool isDead;

    public int killReward = 1;
    
    public HealthBar healthBar;
    
    private void Start()
    {
        nextNode = GameObject.Find("Target Node " + nodeIndex);
        isDead = false;

        GameObject.Find("GameManager").GetComponent<GameManager>().NewAttacker(this);
        
        healthBar = transform.Find("HealthBar").GetComponent<HealthBar>();
        healthBar.SetHealth(health);

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

        healthBar.UpdateHealth(health);
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (String.Compare(other.name, "Target Node " + nodeIndex) == 0)
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
        nodeIndex++;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 1)
        {
            MoneyManager.GiveMoney(killReward);
        }
    }

    public void Kill()
    {
        this.health = 0;
    }
    
}
