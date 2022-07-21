using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class thirtyMinRateButton : MonoBehaviour, IPointerClickHandler
{
    public Button thirtyMinButton;
    public GameObject controller;
    public GameObject storeController;
    public GameObject timer;
    public GameObject timerText;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(timer.GetComponent<timerActive>().getRateTimerActive() == false)
        {
            if(controller.GetComponent<Gems>().getGems() >= 75)
            {
                controller.GetComponent<Gems>().removeGems(75);
                storeController.GetComponent<thirtyMinRate>().thirtyMinRateTimer();
                timerText.GetComponent<rateTimer>().startTimer(1800f);
            }
        }
        else
        {
            CombatTextManager.Instance.CreateText(thirtyMinButton.transform.position, "Already active!", Color.red, false);
        }
    }
}
