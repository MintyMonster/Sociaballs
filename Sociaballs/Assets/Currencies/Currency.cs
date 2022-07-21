using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public long Dollars = 0;


    public long getDollars()
    {
        return Dollars;
    }

    public void setDollars(long amount)
    {
        Dollars = amount;
    }

    public void addDollars(long amount)
    {
        Dollars += amount;
    }

    public void removeDollars(long amount)
    {
        Dollars -= amount;
    }
}
