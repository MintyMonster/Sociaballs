using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenMinRate : MonoBehaviour
{
    public GameObject controller;
    public GameObject timers;

    public void tenMinRateTimer()
    {
        StartCoroutine(tenMinTimer());
    }

    private IEnumerator tenMinTimer()
    {
        controller.GetComponent<UpgradingRate>().changeDoubleRate(true);
        timers.GetComponent<timerActive>().setRateTimer(true);
        yield return new WaitForSeconds(600f);
        controller.GetComponent<UpgradingRate>().changeDoubleRate(false);
        timers.GetComponent<timerActive>().setRateTimer(false);
    }
}
