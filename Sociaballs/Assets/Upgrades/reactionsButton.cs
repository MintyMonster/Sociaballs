using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class reactionsButton : MonoBehaviour, IPointerClickHandler
{

    public static long reactionsLevel = 1;
    public static long reactionsWorth = 2000;

    public GameObject reactionsB;
    public GameObject controller;
    public GameObject reactionsText;

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
    
    public void setReactionsWorth(long amount)
    {
        reactionsWorth = amount;
    }

    public void boostReactions()
    {
        if (controller.GetComponent<UpgradingRate>().GetReactions() >= controller.GetComponent<UpgradingRate>().getReactionsMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= reactionsWorth)
            {
                controller.GetComponent<Currency>().Dollars -= reactionsWorth;
                reactionsLevel++;
                setReactionsWorth(4000 * reactionsLevel + reactionsWorth);
                controller.GetComponent<UpgradingRate>().UpgradeReactions();
            }
            else
            {
                CombatTextManager.Instance.CreateText(reactionsB.transform.position, $"Not enough cash!", Color.red, false);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CollisionExp.reactionsActive)
        {
            if (hasBought)
            {
                boostReactions();
            }
            else
            {
                if(controller.GetComponent<Currency>().getDollars() >= 2000)
                {
                    controller.GetComponent<Currency>().Dollars -= 2000;
                    hasBought = true;
                }
            }
        }
    }

    private void Update()
    {
        if (CollisionExp.reactionsActive)
        {
            if (hasBought)
            {
                if(controller.GetComponent<UpgradingRate>().GetReactions() >= controller.GetComponent<UpgradingRate>().getReactionsMax())
                {
                    reactionsB.GetComponentInChildren<Text>().text = $"${formatKMB(reactionsWorth)}";
                    reactionsText.GetComponent<Text>().text = $"Boost reactions \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetReactions())}/s";
                }
                else
                {
                    reactionsB.GetComponentInChildren<Text>().text = "Max";
                }

            }
            else
            {
                reactionsB.GetComponentInChildren<Text>().text = "Buy";
                reactionsText.GetComponent<Text>().text = "Click to buy for $2000";
            }
        }
        else
        {
            reactionsText.GetComponent<Text>().text = "Locked until \nlevel 15";
            reactionsB.GetComponentInChildren<Text>().text = "Locked";
        }
    }
}
