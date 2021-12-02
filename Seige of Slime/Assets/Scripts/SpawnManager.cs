using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn locations on the map
    public Transform spawnerPos1;
    public Transform spawnerPos2;
    public Transform spawnerPos5;
    public Transform spawnerPos11;

    // Defender prefabs
    public GameObject towerSentry;
    public GameObject antiSlime;
    
    // Attacker prefabs
    public GameObject slimeBlack;
    public GameObject slimeOrange;
    public GameObject slimeRed;
    public GameObject slimeGreen;
    public GameObject slimeYellow;
    
    public GameObject jet;

    private int waveNumber = 0;
    private bool readyToStart = false;
    private bool activeWave = false;

    public GameObject waveCounter;

    private int waveReward = 10;

    private GameObject heldDefender = null; 

    void Update()
    {
        if (readyToStart)
        {
            activeWave = true;
            waveCounter.GetComponent<TextMeshProUGUI>().text = waveNumber + "";
            
            switch (waveNumber) // It aint pretty but it works, apologies to whoever sees this
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
                case 6:
                    StartCoroutine(SpawnWave6(true));
                    break;
                case 7:
                    StartCoroutine(SpawnWave7(true));
                    break;
                case 8:
                    StartCoroutine(SpawnWave8(true));
                    break;
                case 9:
                    StartCoroutine(SpawnWave9(true));
                    break;
                case 10:
                    StartCoroutine(SpawnWave10(true));
                    break;
                case 11:
                    StartCoroutine(SpawnWave11(true));
                    break;
                case 12:
                    StartCoroutine(SpawnWave12(true));
                    break;
                case 13:
                    StartCoroutine(SpawnWave13(true));
                    break;
                case 14:
                    StartCoroutine(SpawnWave14(true));
                    break;
                case 15:
                    StartCoroutine(SpawnWave15(true));
                    break;
                case 16:
                    StartCoroutine(SpawnWave16(true));
                    break;
                case 17:
                    StartCoroutine(SpawnWave17(true));
                    break;
                case 18:
                    StartCoroutine(SpawnWave18(true));
                    break;
                case 19:
                    StartCoroutine(SpawnWave19(true));
                    break;
                case 20:
                    StartCoroutine(SpawnWave20(true));
                    break;
                case 21 :
                    gameObject.GetComponent<GameManager>().GameOver(1);
                    break;
            }
            readyToStart = false;

        }

        if (Input.GetMouseButton(0))
        {
            if (heldDefender != null)
            {
                heldDefender.transform.parent = null;
                heldDefender = null;
            }
        }
        
    }
    
    IEnumerator SpawnWave1(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(1);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave2(bool root)
    {
        StartCoroutine(SpawnWave1(false));
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(2);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave3(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_GreenSlime(1);
            SpawnAttacker_GreenSlime(3);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave4(bool root)
    {
        StartCoroutine(SpawnWave3(false));
        for (int i = 0; i < 15; i++)
        {
            SpawnAttacker_GreenSlime(4);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave5(bool root)
    {
        StartCoroutine(SpawnWave4(false));
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 15; i++)
        {
            SpawnAttacker_GreenSlime(1);
            SpawnAttacker_GreenSlime(2);
            SpawnAttacker_GreenSlime(3);
            yield return new WaitForSeconds(0.2f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave6(bool root)
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_RedSlime(1);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }

    IEnumerator SpawnWave7(bool root)
    {
        StartCoroutine(SpawnWave6(false));
        for (int i = 0; i < 15; i++)
        {
            SpawnAttacker_RedSlime(2);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave8(bool root)
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnAttacker_RedSlime(1);
            SpawnAttacker_RedSlime(3);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave9(bool root)
    {
        StartCoroutine(SpawnWave8(false));
        for (int i = 0; i < 15; i++)
        {
            SpawnAttacker_RedSlime(4);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave10(bool root)
    {
        StartCoroutine(SpawnWave9(false));
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 10; i++)
        {
            SpawnAttacker_RedSlime(1);
            SpawnAttacker_RedSlime(2);
            SpawnAttacker_RedSlime(3);
            yield return new WaitForSeconds(0.2f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave11(bool root)
    {
        StartCoroutine(SpawnWave4(false));
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(SpawnWave6(false));
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 20; i++)
        {
            SpawnAttacker_YellowSlime(3);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave12(bool root)
    {
        StartCoroutine(SpawnWave11(false));
        for (int i = 0; i < 20; i++)
        {
            SpawnAttacker_BlackSlime(1);
            SpawnAttacker_BlackSlime(2);
            SpawnAttacker_BlackSlime(3);
            SpawnAttacker_BlackSlime(4);
            yield return new WaitForSeconds(0.25f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave13(bool root)
    {
        StartCoroutine(SpawnWave12(false));
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 20; i++)
        {
            SpawnAttacker_RedSlime(4);
            SpawnAttacker_OrangeSlime(3);
            SpawnAttacker_BlackSlime(1);
            yield return new WaitForSeconds(0.5f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave14(bool root)
    {
        StartCoroutine(SpawnWave12(false));
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(SpawnWave12(false));
        rootAction(root);
    }
    
    IEnumerator SpawnWave15(bool root)
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnAttacker_Jet(1);
            yield return new WaitForSeconds(1f);
        }
        rootAction(root);
    }
    
    
    IEnumerator SpawnWave16(bool root)
    {
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(SpawnWave14(false));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SpawnWave15(false));
            yield return new WaitForSeconds(5f);

        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave17(bool root)
    {
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(SpawnWave16(false));
            yield return new WaitForSeconds(20f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave18(bool root)
    {
        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                SpawnAttacker_Jet(1);
                SpawnAttacker_Jet(2);
                SpawnAttacker_Jet(3);
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(1f);
        }
        rootAction(root);
    }
    
    IEnumerator SpawnWave19(bool root)
    {
        StartCoroutine(SpawnWave17(false));
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SpawnWave18(false));
        rootAction(root);
    }
    
    IEnumerator SpawnWave20(bool root)
    {
        for (int i = 0; i < 2; i++)
        {
            StartCoroutine(SpawnWave19(false));
            yield return new WaitForSeconds(100f);
        }
        rootAction(root);
    }

    public void rootAction(bool root)
    {
        if (root)
        {
            activeWave = false;
            MoneyManager.GiveMoney(waveReward);
        }
    }
    
    private void SpawnAttacker_GreenSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeGreen, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }
    
    private void SpawnAttacker_RedSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeRed, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }

    private void SpawnAttacker_BlackSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeBlack, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }
    private void SpawnAttacker_OrangeSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeOrange, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }
    
    private void SpawnAttacker_YellowSlime(int spawnerNode)
    {
        GameObject temp = Instantiate(slimeYellow, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }

    private void SpawnAttacker_Jet(int spawnerNode)
    {
        GameObject temp = Instantiate(jet, NodeToSpawner(spawnerNode).position, Quaternion.identity);
        temp.GetComponent<AttackerAi>().nodeIndex = NodeToIndex(spawnerNode);
    }

    private void SpawnDefender_TowerSentry()
    {
        if (heldDefender == null)
        {
            Transform parent = GameObject.Find("MouseObject").transform;
            heldDefender = Instantiate(towerSentry, parent);
            heldDefender.transform.localPosition = Vector3.zero;
            //temp.GetComponent<DefenderAi>().placed = false;
        }
    }
    
    private void SpawnDefender_AntiSlime()
    {
        if (heldDefender == null)
        {
            Transform parent = GameObject.Find("MouseObject").transform;
            heldDefender = Instantiate(antiSlime, parent);
            heldDefender.transform.localPosition = Vector3.zero;
            //temp.GetComponent<DefenderAi>().placed = false;
        }
    }

    public void BuyDefender1()
    {
        if (MoneyManager.TakeMoney(20))
            SpawnDefender_TowerSentry();
    }

    public void BuyDefender2()
    {
        if (MoneyManager.TakeMoney(40))
        {
            SpawnDefender_AntiSlime();
        }
    }
    
    private Transform NodeToSpawner(int spawnerNode)
    {
        if (spawnerNode == 1)
            return spawnerPos1;
        if (spawnerNode == 2)
            return spawnerPos2;
        if (spawnerNode == 3)
            return spawnerPos5;
        return spawnerPos11;
    }

    private int NodeToIndex(int spawnerNode)
    {
        if (spawnerNode == 1)
            return 1;
        if (spawnerNode == 2)
            return 2;
        if (spawnerNode == 3)
            return 5;
        return 11;
    }

    public void NextWave()
    {
        if (!activeWave)
        {
            readyToStart = true;
            waveNumber++;
            waveReward = waveNumber * 2; 
            Debug.Log("Wave reward for wave " + waveNumber + ": " + waveReward);
        }
    }

    public int GetWaveNumber()
    {
        return waveNumber;
    }
}
