using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gemStoreButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public Button generalStore;
    private bool isActive = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        isActive = true;

        if (generalStore.GetComponent<generalStoreButton>().getState() == true)
        {
            
            if (isActive)
            {
                generalStore.GetComponent<generalStoreButton>().hideGeneralStore();
                generalStore.GetComponent<generalStoreButton>().changeState();
                showGemStore();
            }
        }
        else
        {
            if (isActive)
            {
                showGemStore();
            }
        }
    }

    public void showGemStore()
    {
        panel.gameObject.SetActive(true);
    }

    public void hideGemStore()
    {
        panel.gameObject.SetActive(false);
    }

    public bool getState()
    {
        return isActive;
    }

    public void changeState()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }

    
}
