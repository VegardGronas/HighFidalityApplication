using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class UpdateInEditMode : MonoBehaviour
{
    public UIDesignerFunction uiDesignerProfile;
    public List<TextMeshProUGUI> hyperLinks;

    private void Update()
    {
        SetUpHyperlinks();
    }

    public void SetUpHyperlinks()
    {
        foreach (TextMeshProUGUI text in hyperLinks)
        {
            text.color = uiDesignerProfile.linkNormal;
        }
    }
}
