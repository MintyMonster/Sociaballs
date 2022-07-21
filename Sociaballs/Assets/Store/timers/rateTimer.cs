using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rateTimer : MonoBehaviour
{
    public float timeRemaining;
    public bool timerisActive = false;

    public Text timerText;

    public void startTimer(float t)
    {
        timeRemaining = t;
        timerisActive = true;
    }
    private void Update()
    {
        if (timerisActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Timer finished");
                timeRemaining = 0;
                timerText.text = "";
                timerisActive = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
