using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOAnimations : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 backPos;
    public float speed;
    private RectTransform _rectTransform;

    private Vector3 startPos;

    private int click;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        startPos = _rectTransform.anchoredPosition;
    }

    public void AnimateTo()
    {
        StopAllCoroutines();
        _rectTransform.DOAnchorPos(targetPos, speed);
    }

    public void AnimateBack()
    {
        StopAllCoroutines();
        _rectTransform.DOAnchorPos(startPos, speed);
    }

    public void AnimateScaleTo()
    {
        StopAllCoroutines();
        if(click < 1)
        {
            _rectTransform.DOScale(targetPos, speed);
            click++;
        }
        else
        {
            _rectTransform.DOScale(backPos, speed);
            click = 0;
        }
    }
}
