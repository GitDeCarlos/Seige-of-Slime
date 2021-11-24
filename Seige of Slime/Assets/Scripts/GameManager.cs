using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnerPos1;
    public Transform spawnerPos2;
    public Transform spawnerPos5;
    public Transform spawnerPos11;

    public GameObject slimeGreen;
    public GameObject slimeBlack;
    public GameObject slimeRed;
    public GameObject jet;

    private float shootTimerMax;
    private float shootTimer;

    public static List<AttackerAi> attackerList = new List<AttackerAi>();
    
    void Awake()
    {
        shootTimerMax = 0.15f;
    }

    private void Start()
    {
        //SpawnWave1();
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            shootTimer = shootTimerMax;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(slimeGreen, spawnerPos1.position, Quaternion.identity);
            }

            if (Input.GetKey("1"))
            {
                GameObject temp = Instantiate(slimeGreen, spawnerPos1.position, Quaternion.identity);
                temp.GetComponent<AttackerAi>().nodeIndex = 1;
            
            }
            if (Input.GetKey("2"))
            {
                GameObject temp = Instantiate(slimeBlack, spawnerPos2.position, Quaternion.identity);
                temp.GetComponent<AttackerAi>().nodeIndex = 2;
            }
            if (Input.GetKey("3"))
            {
                GameObject temp = Instantiate(slimeRed, spawnerPos5.position, Quaternion.identity);
                temp.GetComponent<AttackerAi>().nodeIndex = 5;
            }
            if (Input.GetKey("4"))
            {
                GameObject temp = Instantiate(jet, spawnerPos11.position, Quaternion.identity);
                temp.GetComponent<AttackerAi>().nodeIndex = 11;
            }
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

    private void SpawnWave1()
    {
        float spawnTime = 0f;
        float timePerSpawn = .6f;

        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_RedSlime(1, spawnerPos1, 500f);
        }
    }

    private void SpawnAttacker_GreenSlime(int spawnerNode, Transform spawner, float timeForSpawn, float timeTilSpawn = 0f)
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
        
    }

}
