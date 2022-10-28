using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> mainWindows;
    public GameObject activeWindow;

    public Color linksActive;
    public Color linksNormal;
    public TextFunctions[] textFuntions;

    public List<Image> mainPanels;
    public Color panelColor;

    public bool isEditingLinksNormal;
    public bool isEditingLinksActive;
    public bool isEditingPanels;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        textFuntions = FindObjectsOfType<TextFunctions>();
        SetUpHyperlinks();
        SetActiveWindow(activeWindow);
        SetUpPanels();
    }

    private void Update()
    {
        if(isEditingPanels) SetUpPanels();
        if (isEditingLinksActive || isEditingLinksNormal)
        {
            SetUpHyperlinks();
        }
    }

    public void SetUpHyperlinks()
    {
        foreach (TextFunctions txt in textFuntions)
        {
            if(isEditingLinksNormal) txt.NormalColor(); 
            else if(isEditingLinksActive) txt.HighlightedColor();
        }
    }

    public void SetUpPanels()
    {
        foreach (Image img in mainPanels)
        {
            img.color = panelColor;
        }
    }

    public void SetActiveWindow(GameObject active)
    {
        foreach (GameObject go in mainWindows)
        {
            if (go != active) go.SetActive(false);
            else go.SetActive(true);
        }
    }
}
