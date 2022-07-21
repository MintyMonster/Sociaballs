using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class twentyMinCashButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject twentyMinButton;
    public GameObject controller;
    public GameObject storeController;
    public GameObject timer;
    public GameObject timerText;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (timer.GetComponent<timerActive>().getCashTimerActive() == false)
        {
            if(controller.GetComponent<Gems>().getGems() >= 50)
            {
                controller.GetComponent<Gems>().removeGems(50);
                storeController.GetComponent<twentyMinCash>().twentyMinCashTimer();
                timerText.GetComponent<cashTimer>().startTimer(1200f);
            }
            
        }
        else
        {
            CombatTextManager.Instance.CreateText(twentyMinButton.transform.position, "Already active!", Color.red, false);
        }
    }
}
