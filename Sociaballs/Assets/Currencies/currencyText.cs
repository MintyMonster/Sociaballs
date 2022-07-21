using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currencyText : MonoBehaviour
{
    public GameObject controller;
    public GameObject ctext;

    static string formatKMB(long num)
    {
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

    private void Update()
    {
        long dollars = controller.GetComponent<Currency>().getDollars();
        ctext.GetComponent<Text>().text = $"${formatKMB(dollars)}";
    }

    private void Awake()
    {
        long dollars = controller.GetComponent<Currency>().getDollars();
        ctext.GetComponent<Text>().text = $"${formatKMB(dollars)}";
    }
}
