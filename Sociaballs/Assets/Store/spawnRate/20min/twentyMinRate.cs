using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twentyMinRate : MonoBehaviour
{
    public GameObject controller;
    public GameObject timers;

    public void twentyMinRateTimer()
    {
        StartCoroutine(twentyMinTimer());
    }

    private IEnumerator twentyMinTimer()
    {
        controller.GetComponent<UpgradingRate>().changeDoubleRate(true);
        timers.GetComponent<timerActive>().setRateTimer(true);
        yield return new WaitForSeconds(1200f);
        controller.GetComponent<UpgradingRate>().changeDoubleRate(false);
        timers.GetComponent<timerActive>().setRateTimer(false);
    }
}
