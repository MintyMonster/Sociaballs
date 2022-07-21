using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adverts_Spawn : MonoBehaviour
{
    public GameObject Ads;
    private float spawnRateAds;
    private float spawnTimeAds;

    private void Start()
    {
        spawnRateAds = 600f;
        spawnTimeAds = 600f;

        InvokeRepeating("SpawnAds", spawnTimeAds, spawnRateAds);
    }

    void SpawnAds()
    {
        Instantiate(Ads, transform.position, transform.rotation);
    }
}
