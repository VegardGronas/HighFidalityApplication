using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctionality : MonoBehaviour
{
    public List<GameObject> scrollableObjects;
    public float mouseSense;
    public bool inverse;

    public InfiniteScroller InfiniteScroller;

    private void Start()
    {
        if (inverse) mouseSense = -mouseSense;
    }

    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            InfiniteScroller.Scroll(Input.mouseScrollDelta.y);
        }
    }
}
