using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnerPos;

    public GameObject slimeGreen;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(slimeGreen, spawnerPos);
        }

        if (Input.GetKey("1"))
        {
            GameObject temp = Instantiate(slimeGreen, spawnerPos);
            temp.GetComponent<AttackerAi>().nodeIndex = 1;
        }
        if (Input.GetKey("2"))
        {
            GameObject temp = Instantiate(slimeGreen, spawnerPos);
            temp.GetComponent<AttackerAi>().nodeIndex = 2;
        }
        if (Input.GetKey("3"))
        {
            GameObject temp = Instantiate(slimeGreen, spawnerPos);
            temp.GetComponent<AttackerAi>().nodeIndex = 5;
        }
        if (Input.GetKey("4"))
        {
            GameObject temp = Instantiate(slimeGreen, spawnerPos);
            temp.GetComponent<AttackerAi>().nodeIndex = 11;
        }
    }
}
