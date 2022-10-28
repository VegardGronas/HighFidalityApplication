using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePanel : MonoBehaviour
{
    public Transform animateTo;
    private Vector3 startPos;
    private float distance;
    public float speed;

    public bool isActive;

    private void Start()
    {
        startPos = transform.position;
    }

    public void ActivatePanel()
    {
        isActive = !isActive;

        if (isActive) EnterPanel();
        else LeavePanel();
    }

    public void EnterPanel()
    {
        StopAllCoroutines();
        distance = Vector3.Distance(transform.position, animateTo.position);
        StartCoroutine(Animate(animateTo.position));
    }

    public void LeavePanel()
    {
        StopAllCoroutines();
        distance = Vector3.Distance(transform.position, startPos);
        StartCoroutine(Animate(startPos));
    }

    IEnumerator Animate(Vector3 finalPos)
    {
        while (distance > .2f)
        {
            distance = Vector3.Distance(transform.position, finalPos);
            transform.position = Vector3.MoveTowards(transform.position, finalPos, speed * Time.deltaTime);
            yield return null;
        }
    }
}
