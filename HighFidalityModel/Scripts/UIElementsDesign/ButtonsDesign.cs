using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsDesign : MonoBehaviour, IPointerEnterHandler
{
    private DesignProfileManager designProfile;
    private Button button;

    private void Start()
    {
        designProfile = GameManager.Instance.designPorfile;

        button = GetComponent<Button>();
        button.colors = designProfile.buttonColor;
    }

    private void Update()
    {
        if (designProfile.edit) Design();
    }

    private void Design()
    {
        button.colors = designProfile.buttonColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }
}
