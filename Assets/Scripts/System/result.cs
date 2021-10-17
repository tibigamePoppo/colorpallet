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
    [SerializeField]
    private Image resultColorA1 = null;
    [SerializeField]
    private Image resultColorA2 = null;

    public void showReselt(bool result,Color color)
    {
        SeManager.Instance.ShotSe(SeType.result);
        if (result == true)
            kekka.sprite = sekai;
        else
            kekka.sprite = husekai;
        resultColor.color = color;
    }

    public void CMShowReselt(bool result, Color color, Color colorA1, Color colorA2)
    {
        SeManager.Instance.ShotSe(SeType.result);
        if (result == true)
            kekka.sprite = sekai;
        else
            kekka.sprite = husekai;
        resultColor.color = color;
        resultColorA1.color = colorA1;
        resultColorA2.color = colorA2;
    }
}
