using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelUpParticles : MonoBehaviour
{
    public ParticleSystem levelup;
    public void startParticles()
    {
        if (!levelup.isPlaying)
        {
            levelup.GetComponent<ParticleSystem>().Play();
        }
    }
}
