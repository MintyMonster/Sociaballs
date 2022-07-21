using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikesCol : MonoBehaviour
{
    public GameObject Followers;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(Followers);
        }
    }
}
