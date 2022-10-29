using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextFunctions : MonoBehaviour
{
    public TextMeshProUGUI text;
    private EventSystem eveSystem;

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;

    public GameObject activeWindow;

    public DesignProfileManager designPorfile;

    private void Start()
    {
        eveSystem = FindObjectOfType<EventSystem>();
        text = GetComponent<TextMeshProUGUI>();

        designPorfile = GameManager.Instance.designPorfile;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (m_Raycaster == null) return;
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(eveSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject != gameObject) return;
                SwapPage();
            }
        }

        if (!designPorfile.edit) return;
        HighlightedColor();
        NormalColor();
    }

    public void SwapPage()
    {
        GameManager.Instance.SetActiveWindow(activeWindow);
    }

    public void HighlightedColor()
    {
        text.color = designPorfile.linkActive;
    }

    public void NormalColor()
    {
        text.color = designPorfile.linkNormal;
    }
}
