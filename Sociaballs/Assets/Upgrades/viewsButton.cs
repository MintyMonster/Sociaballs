using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;

public class viewsButton : MonoBehaviour, IPointerClickHandler
{
    public static long viewsLevel = 1;
    public static long viewsWorth = 30;

    public GameObject viewsB;
    public GameObject controller;
    public GameObject viewsText;


    static string formatKMB(long num)
    {
        if(num >= 100000000000000000)
        {
            return (num / 1000000000000000).ToString("0.#Q");
        }
        if(num >= 1000000000000000)
        {
            return (num / 1000000000000000).ToString("0.##Q");
        }
        if(num >= 100000000000000)
        {
            return (num / 1000000000000).ToString("0.#T");
        }
        if(num >= 1000000000000)
        {
            return (num / 1000000000000).ToString("0.##T");
        }
        if (num >= 100000000000)
        {
            return (num / 1000000000D).ToString("0.#B");
        }
        if (num >= 1000000000)
        {
            return (num / 1000000000D).ToString("0.##B");
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

    public void setViewsWorth(long amount)
    {
        viewsWorth = amount;
    }

    public long getViewsLevel()
    {
        return viewsLevel;
    }
    //2000 * viewsLevel + viewsWorth
    public void boostViews()
    {
        if (controller.GetComponent<UpgradingRate>().GetViews() >= controller.GetComponent<UpgradingRate>().getViewsMax())
        {
            if (controller.GetComponent<Currency>().getDollars() >= viewsWorth)
            {
                controller.GetComponent<Currency>().Dollars -= viewsWorth;
                viewsLevel++;
                setViewsWorth(30 * viewsLevel + viewsWorth);
                controller.GetComponent<UpgradingRate>().UpgradeViews();

            }
            else
            {
                CombatTextManager.Instance.CreateText(viewsB.transform.position, $"Not enough cash!", Color.red, false);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        boostViews();
    }

    private void Update()
    {
        if (controller.GetComponent<UpgradingRate>().GetViews() >= controller.GetComponent<UpgradingRate>().getViewsMax())
        {
            viewsB.GetComponentInChildren<Text>().text = $"${formatKMB(viewsWorth)}";
            viewsText.GetComponent<Text>().text = $"Boost views \nCurrent: {string.Format("{0:0.##}", controller.GetComponent<UpgradingRate>().GetViews())}/s";
        }
        else
        {
            viewsB.GetComponentInChildren<Text>().text = "Max";
        }
    }
}
