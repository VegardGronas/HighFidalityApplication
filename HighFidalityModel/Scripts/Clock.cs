using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteInEditMode]
public class Clock : MonoBehaviour
{
    public TextMeshProUGUI text;


    private void LateUpdate()
    {
        text.text = DateTime.Now.Hour + " : " + DateTime.Now.Minute;
    }
}
