using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsInitialise : MonoBehaviour
{
    string gameId = "3946327";
    bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);    
    }
}
