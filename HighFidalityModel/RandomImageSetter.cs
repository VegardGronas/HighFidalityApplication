using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class RandomImageSetter : MonoBehaviour
{
    public List<Sprite> image;


    private void Start()
    {
        GetComponent<Image>().sprite = image[Random.Range(0, image.Count)];
    }
}
