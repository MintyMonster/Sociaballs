using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class thirtyMinCashButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject thirtyMinButton;
    public GameObject controller;
    public GameObject storeController;
    public GameObject timer;
    public GameObject timerText;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(timer.GetComponent<timerActive>().getCashTimerActive() == false)
        {
            if(controller.GetComponent<Gems>().getGems() >= 75)
            {
                controller.GetComponent<Gems>().removeGems(75);
                storeController.GetComponent<thirtyMinCash>().thirtyMinCashTimer();
                timerText.GetComponent<cashTimer>().startTimer(1800f);
            }
        }
        else
        {
            CombatTextManager.Instance.CreateText(thirtyMinButton.transform.position, "Already active!", Color.red, false);
        }
    }
}
