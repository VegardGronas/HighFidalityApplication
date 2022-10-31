using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagingSystem : MonoBehaviour
{
    public List<RectTransform> instantiatedObjects;
    public GameObject mainObject;
    public Vector2 offset;
    public float speed;

    public TextMeshProUGUI textField;

    public void AddItem()
    {
        GameObject go = Instantiate(mainObject);
        go.transform.SetParent(transform, false);
        go.GetComponentInChildren<TextMeshProUGUI>().text = textField.text;
        instantiatedObjects.Add(go.GetComponent<RectTransform>());
        DropMenus();
    }

    private void DropMenus()
    {
        for (int i = 0; i < instantiatedObjects.Count; i++)
        {
            instantiatedObjects[i].DOAnchorPos(instantiatedObjects[i].anchoredPosition + offset, speed);
        }
    }
}
