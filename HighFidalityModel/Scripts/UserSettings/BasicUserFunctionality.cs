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
        myProfileNameDisplay.text = profile.userName + ", Grimstad";
    }

    public void SetProfilePicture()
    {
        if (!profile.profilePicture) return;
        profilePicture.sprite = profile.profilePicture;
    }
}
