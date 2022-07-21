using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirtyMinCash : MonoBehaviour
{
    public GameObject collision;
    public GameObject timers;


    public void thirtyMinCashTimer()
    {
        StartCoroutine(thirtyMinTimer());
    }

    private IEnumerator thirtyMinTimer()
    {
        collision.GetComponent<CollisionExp>().setDoubleCashState(true);
        timers.GetComponent<timerActive>().setCashTimer(true);
        yield return new WaitForSeconds(1800f);
        collision.GetComponent<CollisionExp>().setDoubleCashState(false);
        timers.GetComponent<timerActive>().setCashTimer(false);
    }
}
