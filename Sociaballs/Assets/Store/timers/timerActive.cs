using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerActive : MonoBehaviour
{
    private bool cashTimerActive = false;
    private bool rateTimerActive = false;
    private bool expTimerActive = false;

    public bool getCashTimerActive()
    {
        return cashTimerActive;
    }

    public void setCashTimer(bool b)
    {
        cashTimerActive = b;
    }

    public bool getRateTimerActive()
    {
        return rateTimerActive;
    }

    public void setRateTimer(bool b)
    {
        rateTimerActive = b;
    }

    public bool getExpTimerActive()
    {
        return expTimerActive;
    }

    public void setExpTimer(bool b)
    {
        expTimerActive = b;
    }
}
