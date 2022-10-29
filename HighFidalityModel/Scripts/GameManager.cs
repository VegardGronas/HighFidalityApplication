using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> mainWindows;
    public GameObject activeWindow;

    public DesignProfileManager designPorfile;

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
        SetActiveWindow(activeWindow);
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
