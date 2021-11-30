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
    
    void Awake()
    {
        //shootTimerMax = 0.15f;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
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

    /*private void SpawnAttacker_GreenSlime(int spawnerNode, Transform spawner, float timeForSpawn, float timeTilSpawn = 0f)
    {
        while (timeTilSpawn > 0f)
        {
            timeTilSpawn -= Time.deltaTime;
        }
        GameObject temp = Instantiate(slimeGreen, spawner.position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;

        while (timeForSpawn > 0f)
        {
            timeForSpawn -= Time.deltaTime;
        }
        
    }
    
    private void SpawnAttacker_RedSlime(int spawnerNode, Transform spawner, float timeForSpawn, float timeTilSpawn = 0f)
    {
        while (timeTilSpawn > 0f)
        {
            timeTilSpawn -= Time.deltaTime;
        }
        GameObject temp = Instantiate(slimeRed, spawner.position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;

        while (timeForSpawn > 0f)
        {
            timeForSpawn -= Time.deltaTime;
            Debug.Log("spawndelay");
        }
        
    }
    
    private void SpawnAttacker_BlackSlime(int spawnerNode, Transform spawner, float timeForSpawn, float timeTilSpawn = 0f)
    {
        while (timeTilSpawn > 0f)
        {
            timeTilSpawn -= Time.deltaTime;
        }
        GameObject temp = Instantiate(slimeBlack, spawner.position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;

        while (timeForSpawn > 0f)
        {
            timeForSpawn -= Time.deltaTime;
        }
        
    }
    
    private void SpawnAttacker_Jet(int spawnerNode, Transform spawner, float timeForSpawn, float timeTilSpawn = 0f)
    {
        while (timeTilSpawn > 0f)
        {
            timeTilSpawn -= Time.deltaTime;
        }
        GameObject temp = Instantiate(jet, spawner.position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;

        while (timeForSpawn > 0f)
        {
            timeForSpawn -= Time.deltaTime;
        }
        
    }*/

    public void GameOver(int status)
    {
        // status 1 means win, status 0 means lose
        if (status == 1)
        {
            
        }
        else
        {
            gameOverText.GetComponent<Text>().text =
                "You Survived: " + (gameObject.GetComponent<SpawnManager>().GetWaveNumber()-1) + " Waves!";
            gameOverScreen.SetActive(true);
        }
    }

}
