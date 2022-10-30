using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public List<GameObject> hideElements;
    public GameObject showElement;

    public void SwapMenu()
    {
        foreach (GameObject go in hideElements)
        {
            go.SetActive(false);
        }

        showElement.SetActive(true);
    }
}
