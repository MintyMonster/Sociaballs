using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewsCol : MonoBehaviour
{
    public GameObject Views;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(Views);
        }
    }
}
