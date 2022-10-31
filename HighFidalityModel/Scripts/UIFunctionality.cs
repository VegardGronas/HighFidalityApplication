using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFunctionality : MonoBehaviour
{
    public List<GameObject> scrollableObjects;
    public float mouseSense;
    public bool inverse;

    public InfiniteScroller InfiniteScroller;
    public float mouseIncrease;

    private float coolDown;
    public float cool = 2f;

    public float lastScroll;

    private void Start()
    {
        if (inverse) mouseSense = -mouseSense;
        coolDown = cool;
    }

    private void Update()
    {
        if (lastScroll != Input.mouseScrollDelta.y && Input.mouseScrollDelta.y != 0) mouseIncrease = 0;
        if (Input.mouseScrollDelta.y != 0)
        {
            coolDown = cool;
            mouseIncrease += Input.mouseScrollDelta.y;
            InfiniteScroller.Scroll(mouseIncrease);
            lastScroll = Input.mouseScrollDelta.y;
        }
        else
        {
            if (coolDown > 0)
            {
                coolDown -= Time.deltaTime;
                return;
            }
            mouseIncrease = 0;
            coolDown = cool;
        }
    }
}
