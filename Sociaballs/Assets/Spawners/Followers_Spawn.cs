using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followers_Spawn : MonoBehaviour
{
    public GameObject Followers;
    public GameObject controller;
    public GameObject followButton;

    private float spawnTimeFollowers = 1f;

    private void Start()
    {
        StartCoroutine(spawnFollowers(spawnTimeFollowers));
    }

    IEnumerator spawnFollowers(float time)
    {
            yield return new WaitForSeconds(time);

            while (true)
            {
            if (CollisionExp.followersActive)
            {
                if (followButton.GetComponent<followsButton>().hasBought)
                {
                    Instantiate(Followers, transform.position, transform.rotation);
                }
            }
            if (controller.GetComponent<UpgradingRate>().getDoubleRate() == false)
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetFollows());
            }
            else
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetFollows() / 2);
            }
            }
    }
}
