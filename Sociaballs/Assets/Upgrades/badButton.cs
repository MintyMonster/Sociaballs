using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class badButton : MonoBehaviour, IPointerClickHandler
{
    public static long badLevel = 1;
    public static long badWorth = 5000;

    public GameObject badB;
    public GameObject controller;
    public GameObject badText;

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

    public void setBadWorth(long amount)
    {
        badWorth = amount;
    }

    public void boostBad()
    {
        if (controller.GetComponent<UpgradingRate>().GetBad() <= controller.GetComponent<UpgradingRate>().getBadMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= badWorth)
            {
                controller.GetComponent<Currency>().Dollars -= badWorth;
                badLevel++;
                setBadWorth(10000 * badLevel + badWorth);
                controller.GetComponent<UpgradingRate>().UpgradeBad();
            }
            else
            {
                CombatTextManager.Instance.CreateText(badB.transform.position, $"Not enough cash!", Color.red, false);
            }
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (CollisionExp.badActive)
        {
            if (hasBought)
            {
                boostBad();
            }
            else
            {
                if(controller.GetComponent<Currency>().getDollars() >= 3000)
                {
                    controller.GetComponent<Currency>().Dollars -= 3000;
                    hasBought = true;
                }
            }
        }
    }

    private void Update()
    {
        if (CollisionExp.badActive)
        {
            if (hasBought)
            {
                if(controller.GetComponent<UpgradingRate>().GetBad() <= controller.GetComponent<UpgradingRate>().getBadMax())
                {
                    badB.GetComponentInChildren<Text>().text = $"${formatKMB(badWorth)}";
                    badText.GetComponent<Text>().text = $"Reduce hate \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetLikes())}/s";
                }
                else
                {
                    badB.GetComponentInChildren<Text>().text = "Max";
                }

            }
            else
            {
                badB.GetComponentInChildren<Text>().text = "Buy";
                badText.GetComponent<Text>().text = "Click to buy for $3000";
            }
        }
        else
        {
            badText.GetComponent<Text>().text = "Locked until \nlevel 25";
            badB.GetComponentInChildren<Text>().text = "Locked";
        }
    }
}
