using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twentyMinCash : MonoBehaviour
{
    public GameObject collision;
    public GameObject timers;

    public void twentyMinCashTimer()
    {
        StartCoroutine(twentyMinTimer());
    }

    private IEnumerator twentyMinTimer()
    {
        collision.GetComponent<CollisionExp>().setDoubleCashState(true);
        timers.GetComponent<timerActive>().setCashTimer(true);
        yield return new WaitForSeconds(1200f);
        collision.GetComponent<CollisionExp>().setDoubleCashState(false);
        timers.GetComponent<timerActive>().setCashTimer(false);
    }
}
