using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum UIELemet { Header, Text }
public class ElementsDesing : MonoBehaviour, IPointerEnterHandler
{
    private DesignProfileManager designProfile;
    private Button button;
    private TextMeshProUGUI text;
    public UIELemet uiElement;

    private void Start()
    {
        designProfile = GameManager.Instance.designPorfile;

        button = GetComponent<Button>();
        text = GetComponent<TextMeshProUGUI>();

        if(button != null) button.colors = designProfile.buttonColor;
    }

    private void Update()
    {
        if (designProfile.edit) Design();
    }

    private void Design()
    {
        if(button != null)  button.colors = designProfile.buttonColor;
        switch (uiElement)
        {
            case UIELemet.Header:
                if (text != null) text.color = designProfile.headerTextColor;
                break;
            case UIELemet.Text:
                if (text != null) text.color = designProfile.textColor;
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
}
