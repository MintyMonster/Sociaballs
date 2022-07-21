using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    public Button upgrade;
    public Button profile;

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
                showStore();
            }
            else
            {
                hideStore();
            }
        }
        else if(profile.GetComponent<profileButton>().getProfileState() == true)
        {
            if (isActive)
            {
                profile.GetComponent<profileButton>().profileHide();
                profile.GetComponent<profileButton>().changeState();
                showStore();
            }
            else
            {
                hideStore();
            }
        }
        else
        {
            if (isActive)
            {
                showStore();
            }
            else
            {
                hideStore();
            }
        }
    }

    public void showStore()
    {
        panel.gameObject.SetActive(true);
    }

    public void hideStore()
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
