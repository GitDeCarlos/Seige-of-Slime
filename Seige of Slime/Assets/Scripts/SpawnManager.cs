using System;
using System.Collections;
using System.Collections.Generic;
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

    String[] wave1 =
    {
        "3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3",
        "5", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2"
    };
    
    String[] wave2 =
    {
        "3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3", "g1", "0.3",
        "5", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2", "r2", "0.2"
    };


    private List<String[]> waves = new List<string[]>();


    private bool startWave = true;

    private void Start()
    {
        /*for (int i = 0; i < 5; i++)
            wave1.Enqueue(slimeGreen);
        
        for (int i = 0; i < 5; i++)
            wave1.Enqueue(slimeRed);
        
        for (int i = 0; i < 20; i++)
            wave2.Enqueue(slimeGreen);*/
        waves.Add(wave1);
        waves.Add(wave2);
    }

    void Update()
    {
        if (startWave)
        {
            Debug.Log("wave " + waveNumber);
            StartCoroutine(SpawnWave(waveNumber));
            waveNumber++;

            startWave = false;

        }
        /*if (countdown <= 0f)
    {
        StartCoroutine(SpawnWave(waveNumber));
        
        
        countdown = timeBetweenWaves;
    }

    countdown -= Time.deltaTime;*/
    }

    IEnumerator SpawnWave(int i)
    {
        if (waveNumber > 2)
            yield break;

        foreach (var q in waves[i-1])
        {Debug.Log(q);
            if (q[0] == 'g' || q[0] == 'r' || q[0] == 'b' || q[0] == 'j')
            { 
                int spawerNode = Int32.Parse(q[1] + "");
                switch (q[0])
                {
                    case 'g':
                        SpawnAttacker_GreenSlime(spawerNode);
                        break;
                    case 'r':
                        SpawnAttacker_RedSlime(spawerNode);
                        break;
                }
            }
            else
            {
                float delay = float.Parse(q);
                //StartCoroutine(delayTimer(delay));
                yield return new WaitForSeconds(delay);
            }
        }

        waveNumber++;
        //yield return new WaitForSeconds(4);
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

    IEnumerator delayTimer(int delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
