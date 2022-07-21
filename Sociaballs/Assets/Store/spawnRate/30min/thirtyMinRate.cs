using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirtyMinRate : MonoBehaviour
{
    public GameObject controller;
    public GameObject timers;

    public void thirtyMinRateTimer()
    {
        StartCoroutine(thirtyMinTimer());
    }

    private IEnumerator thirtyMinTimer()
    {
        controller.GetComponent<UpgradingRate>().changeDoubleRate(true);
        timers.GetComponent<timerActive>().setRateTimer(true);
        yield return new WaitForSeconds(1800f);
        controller.GetComponent<UpgradingRate>().changeDoubleRate(false);
        timers.GetComponent<timerActive>().setRateTimer(false);
    }
}
