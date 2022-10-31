using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BasicUserFunctionality : MonoBehaviour
{
    public TextMeshProUGUI myProfileNameDisplay;
    public DesignProfileManager profile;
    public Image profilePicture;

    public bool showLocation;

    private void OnEnable()
    {
        if (!GameManager.Instance) return;
        profile = GameManager.Instance.designPorfile;
        if (myProfileNameDisplay) myProfileNameDisplay.text = profile.userName + ", Grimstad";
        if (profilePicture) SetProfilePicture();
    }

    private void Start()
    {
        profile = GameManager.Instance.designPorfile;
        if (!myProfileNameDisplay) return;
        if(showLocation) myProfileNameDisplay.text = profile.userName + ", Grimstad";
        else myProfileNameDisplay.text = profile.userName;
    }

    public void SetProfilePicture()
    {
        if (!profile.profilePicture) return;
        profilePicture.sprite = profile.profilePicture;
    }
}
