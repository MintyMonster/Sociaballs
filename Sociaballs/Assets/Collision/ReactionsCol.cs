using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionsCol : MonoBehaviour
{
    public GameObject Reactions;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bottom_UI")
        {
            Destroy(Reactions);
        }
    }
}
