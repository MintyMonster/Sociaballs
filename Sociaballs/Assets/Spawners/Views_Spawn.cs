using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Views_Spawn : MonoBehaviour
{
    public GameObject Views;
    private float spawnTimeViews = 1f;
    public GameObject controller;

    private void Start()
    {
        //spawnRateViews = upgradingRate.GetViews();
        StartCoroutine(spawnViews(spawnTimeViews));
    }

    IEnumerator spawnViews(float time)
    {
        yield return new WaitForSeconds(time);
        
        while (true)
        {
            Instantiate(Views, transform.position, transform.rotation);

            if (controller.GetComponent<UpgradingRate>().getDoubleRate() == false)
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetViews());
            }
            else
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetViews() / 2);
            }
        }
    }
}
