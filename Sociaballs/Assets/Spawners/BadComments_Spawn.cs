using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadComments_Spawn : MonoBehaviour
{
    public GameObject badComments;
    public GameObject controller;
    public GameObject badButton;

    private float spawnTimeBad;

    private void Start()
    {
        StartCoroutine(spawnBad(spawnTimeBad));
    }

    IEnumerator spawnBad(float time)
    {
            yield return new WaitForSeconds(time);
            while (true)
            {
            if (CollisionExp.badActive)
            {
                if (badButton.GetComponent<badButton>().hasBought)
                {
                    Instantiate(badComments, transform.position, transform.rotation);
                }
            }
            yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetBad());
            }
    }
}
