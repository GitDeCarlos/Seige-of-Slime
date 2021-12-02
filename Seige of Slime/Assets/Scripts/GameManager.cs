using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private float shootTimerMax;
    private float shootTimer;

    public static List<AttackerAi> attackerList = new List<AttackerAi>();

    public GameObject gameOverScreen;
    public GameObject gameOverText;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            MoneyManager.GiveMoney(10);
        }
    }

    public Vector3 GetMouseCameraPosition()
    {
        Vector3 position = new Vector3();
        
        return position;
    }
    
    public void NewAttacker(AttackerAi attacker)
    {
        attackerList.Add(attacker);
    }
    
    public AttackerAi GetClosestAttackerAi(Vector3 position, float range)
    {
        AttackerAi closest = null;
        foreach (AttackerAi attacker in attackerList)
        {
            if (attacker.isDead)
            {
                continue;
            }
            if (Vector3.Distance(position, attacker.transform.position) <= range)
            {
                if (closest == null)
                {
                    closest = attacker;
                }
                else
                {
                    if (Vector3.Distance(position, attacker.transform.position) < Vector3.Distance(position, closest.transform.position))
                    {
                        closest = attacker;
                    }
                }
            }
        }

        return closest;
    }

    public void GameOver(int status)
    {
        // status 1 means win, status 0 means lose
        if (status == 1)
        {
            gameOverText.GetComponent<Text>().text = "You Won!";
            gameOverScreen.SetActive(true);
        }
        else
        {
            gameOverText.GetComponent<Text>().text =
                "You Survived: " + (gameObject.GetComponent<SpawnManager>().GetWaveNumber()-1) + " Waves!";
            gameOverScreen.SetActive(true);
        }
    }

}
