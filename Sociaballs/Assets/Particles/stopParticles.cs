using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopParticles : MonoBehaviour
{
    public ParticleSystem sys;

    private void Start()
    {
        sys = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (sys)
        {
            if (!sys.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
