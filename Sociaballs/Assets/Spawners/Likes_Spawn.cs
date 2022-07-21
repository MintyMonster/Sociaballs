using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Likes_Spawn : MonoBehaviour
{
    public GameObject Likes;
    public GameObject controller;
    public GameObject likesbutton;

    private float spawnTimeLikes = 1f;

    //public HandleSpawnTimes handleSpawnTimes;
    //HandleSpawnTimes handleSpawnTimes = new HandleSpawnTimes();
    private void Start()
    {
        StartCoroutine(spawnLikes(spawnTimeLikes));
    }

    IEnumerator spawnLikes(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            if (CollisionExp.likesActive)
            {
                if (likesbutton.GetComponent<likesButton>().hasBought)
                {
                    Instantiate(Likes, transform.position, transform.rotation);
                }
            }

            if (controller.GetComponent<UpgradingRate>().getDoubleRate() == false)
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetLikes());
            }
            else
            {
                yield return new WaitForSeconds(controller.GetComponent<UpgradingRate>().GetLikes() / 2);
            }
        }
    }
}
