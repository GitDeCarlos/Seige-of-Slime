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
    
}
