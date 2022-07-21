using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


[RequireComponent(typeof(Button))]
public class Ads : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3946326";
#elif UNITY_ANDROID
    private string gameId = "3946327";
#endif


    public string myPlacementId = "rewardedVideo";
    bool testMode = true;
    public Button myButton;
    public GameObject controller;
    public GameObject collision;
    private long adsWorth;
    public GameObject panel;


    void Start()
    {
        myButton = GetComponent<Button>();

        myButton.interactable = Advertisement.IsReady(myPlacementId);

        if (myButton) myButton.onClick.AddListener(showRewardedAd);

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        
    }
    private void Update()
    {
        adsWorth = collision.GetComponent<CollisionExp>().getAdsWorth();
    }

    void showRewardedAd()
    {
        Advertisement.Show(myPlacementId);
        panel.SetActive(false);
        
    }
    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            controller.GetComponent<Currency>().Dollars += adsWorth;

        }else if(showResult == ShowResult.Skipped){

        }else if(showResult == ShowResult.Failed)
        {
            Debug.LogWarning("Ad not completed due to an error");
        }

    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // nada
    }

    
    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }
}
