using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class twentyMinRateButton : MonoBehaviour, IPointerClickHandler
{
    public Button twentyMinButton;
    public GameObject controller;
    public GameObject storeController;
    public GameObject timer;
    public GameObject timerText;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(timer.GetComponent<timerActive>().getRateTimerActive() == false)
        {
            if(controller.GetComponent<Gems>().getGems() >= 50)
            {
                controller.GetComponent<Gems>().removeGems(50);
                storeController.GetComponent<twentyMinRate>().twentyMinRateTimer();
                timerText.GetComponent<rateTimer>().startTimer(1200f);
            }
        }
        else
        {
            CombatTextManager.Instance.CreateText(twentyMinButton.transform.position, "Already active!", Color.red, false);
        }
    }
}