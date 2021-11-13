using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class attackerAi : MonoBehaviour
{
    // Holds info for where to move to next
    public GameObject nextNode;
    
    // Attacker's stats
    public int health = 100;
    public double speedMod = 1.0;
    public float velocity = 1;
    
    void FixedUpdate()
    {
        Vector3 newPosition; Debug.Log(nextNode.GetComponent<pathNode>().align);
        if (nextNode.GetComponent<pathNode>().align)
            newPosition = new Vector3(nextNode.transform.position.x, transform.position.y, 0);
        else
            newPosition = new Vector3(transform.position.x , nextNode.transform.position.y, 0);
        
        this.transform.position = newPosition;

    }
}
