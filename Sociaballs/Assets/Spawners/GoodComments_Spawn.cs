using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodComments_Spawn : MonoBehaviour
{
    public GameObject goodComments;
    public GameObject controller;
    public GameObject goodButton;

    private float spawnTimeGood = 1f;

    private void Start()
    {
        StartCoroutine(spawnGoodComments(spawnTimeGood));
    }

    IEnumerator spawnGoodComments(float time)
    {
            yield return new WaitForSeconds(time);

            while (true)
            {
            if (CollisionExp.goodActive)
            {
                if (goodButton.GetComponent<goodButton>().hasBought)
                {
                    Instantiate(goodComments, transform.position, transform.rotation);
                }
            }
            if (controller.GetComponent<UpgradingRate>().getDoubleRate() == false)
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetGood());
            }
            else
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetGood() / 2);
            }
            }
    }
}
