using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctionality : MonoBehaviour
{
    public List<GameObject> scrollableObjects;
    public float mouseSense;
    public bool inverse;

    private void Start()
    {
        if (inverse) mouseSense = -mouseSense;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            foreach (GameObject go in scrollableObjects)
            {
                if(go != null && go.activeInHierarchy)
                {
                    go.transform.position +=
                        new Vector3(0, Input.mouseScrollDelta.y * mouseSense, 0);
                }
            }
        }
    }
}
