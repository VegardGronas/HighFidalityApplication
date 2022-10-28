using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour
{
    public float mouseSpeed;
    public float speed;

    public void Scroll(float scrolling)
    {
        speed = scrolling * mouseSpeed;
        transform.position += new Vector3(0, speed, 0);
    }
}
