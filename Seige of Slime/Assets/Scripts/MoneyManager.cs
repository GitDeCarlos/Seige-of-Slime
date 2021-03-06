using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int myMoney;
    private int startMoney = 30;
    private int maxMoney = 999;

    public GameObject moneyCounter;

    void Start()
    {
        myMoney = startMoney;
    }

    void Update()
    {
        if (myMoney > maxMoney)
        {
            myMoney = maxMoney;
        }
        moneyCounter.GetComponent<TextMeshProUGUI>().text = "$" + myMoney;
    }

    public static void GiveMoney(int money)
    {
        myMoney += money;
    }

    public static bool TakeMoney(int money)
    {
        if (myMoney >= money)
        {
            myMoney -= money;
            return true;
        }
        else return false;
    }
}
