using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DesingProfile", menuName = "Design/Profile", order = 1)]
public class DesignProfileManager : ScriptableObject
{
    public bool edit;
    public Color linkNormal;
    public Color linkActive;
    public Color panelTint;
    public Sprite panelImage;

    public ColorBlock buttonColor;

    public Color headerTextColor;
    public Color textColor;
}
