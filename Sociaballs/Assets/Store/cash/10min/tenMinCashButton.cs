using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tenMinCashButton : MonoBehaviour, IPointerClickHandler {

    public Button tenMinButton;
    public GameObject controller;
    public GameObject storeController;
    public GameObject timer;
    public GameObject timerText;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (timer.GetComponent<timerActive>().getCashTimerActive() == false)
        {
            if (controller.GetComponent<Gems>().getGems() >= 25)
            {
                controller.GetComponent<Gems>().removeGems(25);
                storeController.GetComponent<tenMinCash>().tenMinCashTimer();
                timerText.GetComponent<cashTimer>().startTimer(600f);
            }
        }
        else
        {
            CombatTextManager.Instance.CreateText(tenMinButton.transform.position, "Already active!", Color.red, false);
        }
    }
}
