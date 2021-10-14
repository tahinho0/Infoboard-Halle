using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;

public class Fullit : MonoBehaviour
{
    public GameObject bar;
    public int time;

    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 1, time);
    }
}