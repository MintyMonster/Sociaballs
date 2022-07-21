using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adsPanel : MonoBehaviour
{
    public GameObject text;
    public GameObject collision;
    private long adsWorth;
    void Update()
    {
        adsWorth = collision.GetComponent<CollisionExp>().getAdsWorth();
        text.GetComponent<Text>().text = $"Watch an ad for ${adsWorth}";
    }
}
