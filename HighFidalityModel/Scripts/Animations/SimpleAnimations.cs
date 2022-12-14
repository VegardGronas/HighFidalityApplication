using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleAnimation
{
    public enum AnimationType { Linear, PingPong }
    public enum Affection { MouseEnter, MouseExit, MouseStay, MouseClick }
    public enum AnimatedElement { text, gameobject}
    public class SimpleAnimatoionManager : MonoBehaviour
    {
        public RectTransform _rectTransfrom;

        public AnimationType animationType;
        public Affection affection;
        public AnimatedElement animationElement;
        public Vector2 animateTo;
        public float moveSpeed = 5f;

        private Vector2 startPos;

        private void Start()
        {
            if(_rectTransfrom.gameObject == null) _rectTransfrom = GetComponent<RectTransform>();
            startPos = _rectTransfrom.anchoredPosition;
        }

        public Vector2 LinearAnimation(Vector2 from, Vector2 to, float speed)
        {
            return Vector2.Lerp( from, to, speed * Time.deltaTime);
        }

        public void StartAnimateTo()
        {
            StopAllCoroutines();
            StartCoroutine(AnimateTo());
        }

        public void StartAnimateBack()
        {
            StopAllCoroutines();
            StartCoroutine(AnimateBack());
        }

        public void StartAnimateByAmount()
        {
            animateTo = _rectTransfrom.anchoredPosition + animateTo;
            StopAllCoroutines();
            StartCoroutine(AnimateByAmount());
        }

        private IEnumerator AnimateTo()
        {
            while (_rectTransfrom.anchoredPosition != animateTo)
            {
                _rectTransfrom.anchoredPosition = LinearAnimation(_rectTransfrom.anchoredPosition, animateTo, moveSpeed);
                yield return null;
            }
        }

        private IEnumerator AnimateByAmount()
        {
            while (_rectTransfrom.anchoredPosition != animateTo)
            {
                _rectTransfrom.anchoredPosition = LinearAnimation(_rectTransfrom.anchoredPosition, animateTo, moveSpeed);
                yield return null;
            }
        }

        private IEnumerator AnimateBack()
        {
            while (_rectTransfrom.anchoredPosition != animateTo)
            {
                _rectTransfrom.anchoredPosition = LinearAnimation(_rectTransfrom.anchoredPosition, startPos, moveSpeed);
                yield return null;
            }
        }
    }
}