using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class generalStoreButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public GameObject gemStore;
    private bool isActive = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        isActive = true;
        if (gemStore.GetComponent<gemStoreButton>().getState() == true)
        {
            if (isActive)
            {
                gemStore.GetComponent<gemStoreButton>().hideGemStore();
                gemStore.GetComponent<gemStoreButton>().changeState();
                showGeneralStore();
            }
        }
        else
        {
            if (isActive)
            {
                showGeneralStore();
            }
        }
    }

    public void showGeneralStore()
    {
        panel.gameObject.SetActive(true);
    }

    public void hideGeneralStore()
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
