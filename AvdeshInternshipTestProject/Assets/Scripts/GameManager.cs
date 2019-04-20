using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    public Text moneyText;

    public int money = 50;

    private void Start()
    {
        InvokeRepeating("PowerPlant", 5f, 5f);
    }

    public void Update()
    {
        moneyText.text = money.ToString();
    }

    public void addMoney(int amount)
    {
        money += amount;
    }

    public void subMoney(int amount)
    {
        money -= amount;
    }
    void PowerPlant()
    {
        if (money < 250)
        {
            money++;
        }else
        {
            CancelInvoke("PowerPlant");
        }
    }
}
