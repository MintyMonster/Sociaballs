using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCommentsCol : MonoBehaviour
{

    public GameObject BadComments;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(BadComments);
        }
    }
}
