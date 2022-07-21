using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class likesButton : MonoBehaviour, IPointerClickHandler
{
    public static long likesLevel = 1;
    public static long likesWorth = 500;

    public GameObject likesB;
    public GameObject controller;
    public GameObject likesText;

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

    public void setLikesWorth(long amount)
    {
        likesWorth = amount;
    }

    public long getLikesLevel()
    {
        return likesLevel;
    }

    public void boostLikes()
    {
        if (controller.GetComponent<UpgradingRate>().GetLikes() >= controller.GetComponent<UpgradingRate>().getLikesMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= likesWorth)
            {
                controller.GetComponent<Currency>().Dollars -= likesWorth;
                likesLevel++;
                setLikesWorth(1000 * likesLevel + likesWorth);
                controller.GetComponent<UpgradingRate>().UpgradeLikes();
            }
            else
            {
                CombatTextManager.Instance.CreateText(likesB.transform.position, $"Not enough cash!", Color.red, false);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (CollisionExp.likesActive)
        {
            if (hasBought)
            {
                boostLikes();
            }
            else
            {
                if(controller.GetComponent<Currency>().getDollars() >= 1000)
                {
                    controller.GetComponent<Currency>().Dollars -= 1000;
                    hasBought = true;
                }
            }
        }
    }

    private void Update()
    {

        if (CollisionExp.likesActive)
        {
            if (hasBought)
            {
                if (controller.GetComponent<UpgradingRate>().GetLikes() >= controller.GetComponent<UpgradingRate>().getLikesMax())
                {
                    likesB.GetComponentInChildren<Text>().text = $"${formatKMB(likesWorth)}";
                    likesText.GetComponent<Text>().text = $"Boost likes \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetLikes())}/s";
                }
                else
                {
                    likesB.GetComponentInChildren<Text>().text = "Max";
                }
            }
            else
            {
                likesB.GetComponentInChildren<Text>().text = "Buy";
                likesText.GetComponent<Text>().text = "Click to buy for $1000:";
            }

        }
        else
        {
            likesText.GetComponent<Text>().text = "Locked until \nlevel 5";
            likesB.GetComponentInChildren<Text>().text = "Locked";
        }
    }
}
