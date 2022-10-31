using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSwapper : MonoBehaviour
{
    public GameObject showMenu;

    public void SwapPage()
    {
        GameManager.Instance.SetActiveWindow(showMenu);
    }
}
