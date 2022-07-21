using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class profileStats : MonoBehaviour
{
    public Text views;
    public Text likes;
    public Text follows;
    public Text reactions;
    public Text good;
    public Text bad;

    public long totalViews = 0;
    public long totalLikes = 0;
    public long totalFollows = 0;
    public long totalReactions = 0;
    public long totalGood = 0;
    public long totalBad = 0;

    public long level;


    public long getTotalViews()
    {
        return totalViews;
    }
    public long getTotalLikes()
    {
        return totalLikes;
    }

    public long getTotalFollows()
    {
        return totalFollows;
    }

    public long getTotalReactions()
    {
        return totalReactions;
    }

    public long getTotalGood()
    {
        return totalGood;
    }

    public long getTotalBad()
    {
        return totalBad;
    }

    public void addTotalViews(long amount)
    {
        totalViews += amount;
    }
    public void addTotalLikes(long amount)
    {
        totalLikes += amount;
    }

    public void addTotalFollows(long amount)
    {
        totalFollows += amount;
    }

    public void addTotalReactions(long amount)
    {
        totalReactions += amount;
    }

    public void addTotalGood(long amount)
    {
        totalGood += amount;
    }

    public void addTotalBad(long amount)
    {
        totalBad += amount;
    }

    private void Update()
    {
        views.GetComponent<Text>().text = $"Total views: {totalViews}";
        likes.GetComponent<Text>().text = $"Total likes: {totalLikes}";
        follows.GetComponent<Text>().text = $"Total follows: {totalFollows}";
        reactions.GetComponent<Text>().text = $"Total reactions: {totalReactions}";
        good.GetComponent<Text>().text = $"Total comments: {totalGood}";
        bad.GetComponent<Text>().text = $"Total hate: {totalBad}";
    }
}
