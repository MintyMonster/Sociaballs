using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class goodButton : MonoBehaviour, IPointerClickHandler
{
    public static long goodLevel = 1;
    public static long goodWorth = 5000;

    public GameObject goodB;
    public GameObject controller;
    public GameObject goodText;

    public bool hasBought = false;

    static string formatKMB(long num)
    {
        if (num >= 100000000000000000)
        {
            return (num / 1000000000000000).ToString("0.#Q");
        }
        if (num >= 1000000000000000)
        {
            return (num / 1000000000000000).ToString("0.##Q");
        }
        if (num >= 100000000000000)
        {
            return (num / 1000000000000).ToString("0.#T");
        }
        if (num >= 1000000000000)
        {
            return (num / 1000000000000).ToString("0.##T");
        }
        if (num >= 100000000000)
        {
            return (num / 1000000000D).ToString("0.#B");
        }
        if (num >= 1000000000)
        {
            return (num / 1000000000).ToString("0.##B");
        }
        if (num >= 100000000)
        {
            return (num / 1000000D).ToString("0.#M");
        }
        if (num >= 1000000)
        {
            return (num / 1000000D).ToString("0.##M");
        }
        if (num >= 100000)
        {
            return (num / 1000D).ToString("0.#k");
        }
        if (num >= 10000)
        {
            return (num / 1000D).ToString("0.##k");
        }
        return num.ToString("#,0");
    }

    public void setGoodWorth(long amount)
    {
        goodWorth = amount;
    }

    public void boostGood()
    {
        if (controller.GetComponent<UpgradingRate>().GetGood() >= controller.GetComponent<UpgradingRate>().getGoodMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= goodWorth)
            {
                controller.GetComponent<Currency>().Dollars -= goodWorth;
                goodLevel++;
                setGoodWorth(10000 * goodLevel + goodWorth);
                controller.GetComponent<UpgradingRate>().UpgradeGood();
            }
            else
            {
                CombatTextManager.Instance.CreateText(goodB.transform.position, $"Not enough cash!", Color.red, false);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CollisionExp.goodActive)
        {
            if (hasBought)
            {
                boostGood();
            }
            else
            {
                if(controller.GetComponent<Currency>().getDollars() >= 2500)
                {
                    controller.GetComponent<Currency>().Dollars -= 2500;
                    hasBought = true;
                }
            }
        }
    }

    private void Update()
    {
        if (CollisionExp.goodActive)
        {
            if (hasBought)
            {
                if(controller.GetComponent<UpgradingRate>().GetGood() >= controller.GetComponent<UpgradingRate>().getGoodMax())
                {
                    goodB.GetComponentInChildren<Text>().text = $"${formatKMB(goodWorth)}";
                    goodText.GetComponent<Text>().text = $"Boost positivity \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetGood())}/s";
                }
                else
                {
                    goodB.GetComponentInChildren<Text>().text = "Max";
                }
            }
            else
            {
                goodB.GetComponentInChildren<Text>().text = "Buy";
                goodText.GetComponent<Text>().text = "Click to buy for $2500";
            }

        }
        else
        {
            goodText.GetComponent<Text>().text = "Locked until \nlevel 20";
            goodB.GetComponentInChildren<Text>().text = "Locked";
        }
    }
}
