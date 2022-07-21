using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class profileButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public Button upgrade;
    public Button store;
    [SerializeField] private bool isActive;

    public void OnPointerClick(PointerEventData eventData)
    {

        isActive = !isActive;

        if(upgrade.GetComponent<upgradeButton>().getState() == true)
        {
            
            if (isActive)
            {
                upgrade.GetComponent<upgradeButton>().upgradeHide();
                upgrade.GetComponent<upgradeButton>().changeState();
                profileShow();
            }
            else
            {
                profileHide();
            }
        }
        else if(store.GetComponent<StoreButton>().getState() == true)
        {
            if (isActive)
            {
                store.GetComponent<StoreButton>().hideStore();
                store.GetComponent<StoreButton>().changeState();
                profileShow();
            }
            else
            {
                profileHide();
            }
        }
        else
        {
            if (isActive)
            {
                profileShow();
            }
            else
            {
                profileHide();
            }
        }
    }

    public void profileShow()
    {
        panel.gameObject.SetActive(true);
    }

    public void profileHide()
    {
        panel.gameObject.SetActive(false);
    }

    public bool getProfileState()
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
