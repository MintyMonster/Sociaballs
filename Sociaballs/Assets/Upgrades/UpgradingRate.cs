using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradingRate : MonoBehaviour
{
    private float viewsRate = 4.2f;
    private float viewsMax = 0.4f;

    private float likesRate = 6.2f;
    private float likesMax = 0.6f;

    private float followsRate = 9.2f;
    private float followsMax = 1.4f;

    private float reactionsRate = 12.2f;
    private float reactionsMax = 2f;

    private float goodRate = 15f;
    private float goodMax = 3f;

    private float badRate = 10f;
    private float badMax = 40f;

    private float adsRate = 600f;

    private bool doubleRate = false;

    public bool getDoubleRate()
    {
        return doubleRate;
    }

    public void changeDoubleRate(bool b)
    {
        doubleRate = b;
    }

    // Views
    // upgrade views by removing 0.2s off of spawntime.
    public void UpgradeViews() { 

        if(viewsRate > viewsMax)
        {
            viewsRate -= 0.1f;
        }
    }

    // return the rate at which views spawn.
    public float GetViews()
    {
        return Mathf.Abs(viewsRate);
    }

    public void SetViews(float rate)
    {
        viewsRate = rate;
    }

    // Likes

    public void UpgradeLikes()
    {
        if(likesRate >= likesMax)
        {
            likesRate -= 0.1f;
        }
    }

    public float GetLikes()
    {
        return Mathf.Abs(likesRate);
    }

    public void SetLikes(float rate)
    {
        likesRate = rate;
    }

    // Follows

    public void UpgradeFollows()
    {
        if(followsRate >= followsMax)
        {
            followsRate -= 0.1f;
        }
    }

    public float GetFollows()
    {
        return Mathf.Abs(followsRate);
    }

    public void SetFollows(float rate)
    {
        followsRate = rate;
    }

    // Reactions

    public void UpgradeReactions()
    {
        if(reactionsRate >= reactionsMax)
        {
            reactionsRate -= 0.1f;
        }
    }

    public float GetReactions()
    {
        return Mathf.Abs(reactionsRate);
    }
    
    public void SetReactions(float rate)
    {
        reactionsRate = rate;
    }

    // Good comments

    public void UpgradeGood()
    {
        if(goodRate >= goodMax)
        {
            goodRate -= 0.1f;
        }
    }

    public float GetGood()
    {
        return Mathf.Abs(goodRate);
    }

    public void SetGood(float rate)
    {
        goodRate = rate;
    }

    // Bad comments

    public void UpgradeBad()
    {
        if(badRate <= badMax)
        {
            badRate += 0.1f;
        }
    }

    public float GetBad()
    {
        return Mathf.Abs(badRate);
    }

    public void SetBad(float rate)
    {
        badRate = rate;
    }

    // Ads

    public float GetAds()
    {
        return adsRate;
    }

    // Max

    public float getViewsMax()
    {
        return viewsMax;
    }

    public float getLikesMax()
    {
        return likesMax;
    }

    public float getFollowsMax()
    {
        return followsMax;
    }

    public float getReactionsMax()
    {
        return reactionsMax;
    }

    public float getGoodMax()
    {
        return goodMax;
    }

    public float getBadMax()
    {
        return badMax;
    }
}
