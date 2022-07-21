using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class closeAdPanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject adsPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        adsPanel.gameObject.SetActive(false);
    }
}
