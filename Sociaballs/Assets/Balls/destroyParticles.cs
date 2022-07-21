using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyParticles : MonoBehaviour
{
    public GameObject particles;

    void OnMouseDown()
    {
        Instantiate(particles, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
