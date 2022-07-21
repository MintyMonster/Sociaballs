using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenMinCash : MonoBehaviour
{
    public GameObject collision;
    public GameObject controller;
    public GameObject timers;

    private void Start()
    {
        controller.GetComponent<Gems>().addGems(100);
    }

    public void tenMinCashTimer()
    {
        StartCoroutine(tenMinTimer());
    }

    private IEnumerator tenMinTimer()
    {
        collision.GetComponent<CollisionExp>().setDoubleCashState(true);
        timers.GetComponent<timerActive>().setCashTimer(true);
        yield return new WaitForSeconds(600f);
        collision.GetComponent<CollisionExp>().setDoubleCashState(false);
        timers.GetComponent<timerActive>().setCashTimer(false);
    }
}
