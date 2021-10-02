using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    [SerializeField]
    private Sprite sekai = null;
    [SerializeField]
    private Sprite husekai = null;
    [SerializeField]
    private Image kekka = null;
    [SerializeField]
    private Image resultColor = null;

    public void showReselt(bool result,Color color)
    {
        if (result == true)
            kekka.sprite = sekai;
        else
            kekka.sprite = husekai;
        resultColor.color = color;
    }
}
