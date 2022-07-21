using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class followsButton : MonoBehaviour, IPointerClickHandler
{

    public static long followsLevel = 1;
    public static long followsWorth = 1200;

    public GameObject followsB;
    public GameObject controller;
    public GameObject followsText;

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

    public void setFollowsWorth(long amount)
    {
        followsWorth = amount;
    }

    public void boostFollows()
    {
        if (controller.GetComponent<UpgradingRate>().GetFollows() >= controller.GetComponent<UpgradingRate>().getFollowsMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= followsWorth)
            {
                controller.GetComponent<Currency>().Dollars -= followsWorth;
                followsLevel++;
                setFollowsWorth(2400 * followsLevel + followsWorth);
                controller.GetComponent<UpgradingRate>().UpgradeFollows();
            }
            else
            {
                CombatTextManager.Instance.CreateText(followsB.transform.position, $"Not enough cash!", Color.red, false);

            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (CollisionExp.followersActive)
        {
            if (hasBought)
            {
                boostFollows();
            }
            else
            {
                if (controller.GetComponent<Currency>().getDollars() >= 1500)
                {
                    controller.GetComponent<Currency>().Dollars -= 1500;
                    hasBought = true;
                }
            }
        }
    }
    
    private void Update()
    {
        if (CollisionExp.followersActive)
        {
            if (hasBought)
            {
                if(controller.GetComponent<UpgradingRate>().GetFollows() >= controller.GetComponent<UpgradingRate>().getFollowsMax())
                {
                    followsB.GetComponentInChildren<Text>().text = $"${formatKMB(followsWorth)}";
                    followsText.GetComponent<Text>().text = $"Boost follows \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetFollows())}/s";
                }
                else
                {
                    followsB.GetComponentInChildren<Text>().text = "Max";
                }
            }
            else
            {
                followsText.GetComponent<Text>().text = "Click to buy for $1500";
                followsB.GetComponentInChildren<Text>().text = "Buy";
            }
        }
        else
        {
            followsText.GetComponent<Text>().text = "Locked until level 10";
            followsB.GetComponentInChildren<Text>().text = "Locked";
        }
    }
}
