using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour
{
    public float mouseSpeed;
    public float speed;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void Scroll(float scrolling)
    {
        if (!gameObject.activeInHierarchy) return;
        speed = scrolling * mouseSpeed;
        Vector2 rectMove = new Vector2(0, speed);
        rectTransform.DOLocalMove(rectTransform.anchoredPosition + rectMove, 1f);
    }
}
