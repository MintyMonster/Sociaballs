using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodCommentsCol : MonoBehaviour
{
    public GameObject GoodComments;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(GoodComments);
        }
    }
}
