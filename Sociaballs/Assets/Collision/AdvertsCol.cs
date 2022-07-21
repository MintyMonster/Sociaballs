using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertsCol : MonoBehaviour
{
    public GameObject Adverts;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(Adverts);
        }
    }
}
