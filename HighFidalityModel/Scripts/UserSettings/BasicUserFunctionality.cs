using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicUserFunctionality : MonoBehaviour
{
    public TextMeshProUGUI myProfileNameDisplay;
    public DesignProfileManager profile;

    private void OnEnable()
    {
        if (!GameManager.Instance) return;
        profile = GameManager.Instance.designPorfile;
        myProfileNameDisplay.text = profile.userName + ", Grimstad";
    }

    private void Start()
    {
        profile = GameManager.Instance.designPorfile;
        myProfileNameDisplay.text = profile.userName + ", Grimstad";
    }
}
