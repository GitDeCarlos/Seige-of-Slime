using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnerPos1;
    public Transform spawnerPos2;
    public Transform spawnerPos5;
    public Transform spawnerPos11;

    public GameObject slimeGreen;
    public GameObject slimeBlack;
    public GameObject slimeRed;
    public GameObject jet;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveNumber = 1;
    private bool readyToStart = false;
    private bool activeWave = false;

    public GameObject waveCounter;

    private int waveReward = 100;

    void Update()
    {
        if (readyToStart)
        {
            activeWave = true;
            waveCounter.GetComponent<TextMeshProUGUI>().text = waveNumber + "";
            switch (waveNumber)
            {
                case 1:
                    StartCoroutine(SpawnWave1(true));
                    break;
                case 2:
                    StartCoroutine(SpawnWave2(true));
                    break;
                case 3:
                    StartCoroutine(SpawnWave3(true));
                    break;
                case 4:
                    StartCoroutine(SpawnWave4(true));
                    break;
                case 5:
                    StartCoroutine(SpawnWave5(true));
                    break;
            }
            waveNumber++;
            readyToStart = false;

        }
        
    }
    
    IEnumerator SpawnWave1(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(1);
            yield return new WaitForSeconds(0.3f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave2(bool root)
    {
        StartCoroutine(SpawnWave1(false));
        for (int i = 0; i < 5; i++)
        {
            SpawnAttacker_GreenSlime(2);
            yield return new WaitForSeconds(0.3f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave3(bool root)
    {
        StartCoroutine(SpawnWave2(false));
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 7; i++)
        {
            SpawnAttacker_RedSlime(2);
            yield return new WaitForSeconds(0.3f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave4(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(1);
            yield return new WaitForSeconds(0.3f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave5(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(1);
            yield return new WaitForSeconds(0.3f);
        }
        rootAction(root);
    }

    public void rootAction(bool root)
    {
        if (root)
        {
            activeWave = false;
            MoneyManager.GiveMoney(waveReward); Debug.Log("Active wave over");
        }
    }
    
    private void SpawnAttacker_GreenSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeGreen, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;
    }
    
    private void SpawnAttacker_RedSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeRed, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = spawnerNode;
    }

    private Transform NodeToSpawner(int spawnerNode)
    {
        if (spawnerNode == 1)
            return spawnerPos1;
        else if (spawnerNode == 2)
            return spawnerPos2;
        else if (spawnerNode == 3)
            return spawnerPos5;
        else return spawnerPos11;
    }

    public void NextWave()
    {
        if (!activeWave)
        {
            readyToStart = true;
        }
    }
}
