using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carousel : MonoBehaviour
{
    public RectTransform frameSize;
    public RectTransform rectTransfrom;
    public float speed;
    public int imageCount;
    public int currentImage = 0;

    public void Animate(int num)
    {
        StopAllCoroutines();

        if (currentImage <= imageCount - 1 && num > 0) currentImage += num;
        else if (currentImage >= 1 && num < 0) currentImage -= (num * num);
        else return;
        rectTransfrom.DOAnchorPosX(-frameSize.rect.width * currentImage, speed);
    }
}
