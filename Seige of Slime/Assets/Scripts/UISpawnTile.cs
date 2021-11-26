using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpawnTile : MonoBehaviour
{
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void PurchaseDefender()
    {
        Debug.Log("click");
    }
}
