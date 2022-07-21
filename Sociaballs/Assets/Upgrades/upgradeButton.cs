using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class upgradeButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public Button Upgrade;
    public Button profile;
    public Button store;
    [SerializeField] private bool upgradeActive = false;


    public void OnPointerClick(PointerEventData eventData)
    {
        upgradeActive = !upgradeActive;

        if (profile.GetComponent<profileButton>().getProfileState() == true)
        {
            
            if (upgradeActive)
            {
                profile.GetComponent<profileButton>().profileHide();
                profile.GetComponent<profileButton>().changeState();
                upgradeShow();
            }
            else
            {
                upgradeHide();
            }
        }
        else if(store.GetComponent<StoreButton>().getState() == true)
        {
            if (upgradeActive)
            {
                store.GetComponent<StoreButton>().hideStore();
                store.GetComponent<StoreButton>().changeState();
                upgradeShow();
            }
            else
            {
                upgradeHide();
            }
        }
        else
        {
            if (upgradeActive)
            {
                upgradeShow();
            }
            else
            {
                upgradeHide();
            }
        }
    }

    public void upgradeShow()
    {
        panel.SetActive(true);
    }

    public void upgradeHide()
    {
        panel.SetActive(false);
    }

    public bool getState()
    {
        return upgradeActive;
    }

    public void changeState()
    {
        if (upgradeActive)
        {
            upgradeActive = false;
        }
        else
        {
            upgradeActive = true;
        }
    }
}
