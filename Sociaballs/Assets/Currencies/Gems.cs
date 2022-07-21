using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gems : MonoBehaviour
{
    private long currencyGems = 0;

    public long getGems()
    {
        return currencyGems;
    }

    public void setGems(long amount)
    {
        currencyGems = amount;
    }

    public void addGems(long amount)
    {
        currencyGems += amount;
    }

    public void removeGems(long amount)
    {
        currencyGems -= amount;
    }
}
