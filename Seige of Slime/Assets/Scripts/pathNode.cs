using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathNode : MonoBehaviour
{
    // To pass along the next node in the series once attackers reach this one
    public GameObject nextNode;
    
    // To know if this node is last in the series
    public bool tailNode;
    
    // Tells attackers the necessary alignment to find node
    // true for x, false for y
    public bool align;

    
}
