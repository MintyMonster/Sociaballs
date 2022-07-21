using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactions_Spawn : MonoBehaviour
{
    public GameObject Reactions;
    public GameObject controller;
    public GameObject reactionsButton;

    private float spawnTimeReactions;

    private void Start()
    {
        StartCoroutine(spawnReactions(spawnTimeReactions));
    }

    IEnumerator spawnReactions(float time)
    {
            yield return new WaitForSeconds(time);

            while (true)
            {
            if (CollisionExp.reactionsActive)
            {
                if (reactionsButton.GetComponent<reactionsButton>().hasBought)
                {
                    Instantiate(Reactions, transform.position, transform.rotation);
                }
            }
            if (controller.GetComponent<UpgradingRate>().getDoubleRate() == false)
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetReactions());
            }
            else
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetReactions() / 2);
            }
            }
    }
}
