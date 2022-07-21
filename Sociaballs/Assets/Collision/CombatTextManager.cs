using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
    private static CombatTextManager instance;

    public GameObject textPrefab;
    public RectTransform canvasParent;
    public RectTransform messagesParent;
    public float speed;
    public Vector3 direction;
    public float fadeTime;
    public bool balls;

    public static CombatTextManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }

    public void CreateText(Vector3 position, string text, Color color, bool balls)
    {
        GameObject sct = Instantiate(textPrefab, position, Quaternion.identity);

        if (!balls)
        {
            sct.transform.SetParent(canvasParent);
        }
        else
        {
            sct.transform.SetParent(messagesParent);
        }
        sct.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        sct.GetComponent<CombatText>().Initialise(speed, direction, fadeTime, balls);
        sct.GetComponent<Text>().text = text;
        sct.GetComponent<Text>().color = color;
        
    }
}
