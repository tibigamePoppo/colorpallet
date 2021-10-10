using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class colorPallet : MonoBehaviour
{
    public ReactiveProperty<Color> colorImage = new ReactiveProperty<Color>();
    [SerializeField]
    Slider RValue;
    [SerializeField]
    Slider GValue;
    [SerializeField]
    Slider BValue;
    [SerializeField]
    Slider HValue;
    [SerializeField]
    Slider SValue;
    [SerializeField]
    Slider VValue;

    [SerializeField]
    Text RValueText;
    [SerializeField]
    Text GValueText;
    [SerializeField]
    Text BValueText;
    [SerializeField]
    Text HValueText;
    [SerializeField]
    Text SValueText;
    [SerializeField]
    Text VValueText;
    void Start()
    {
        gameObject.SetActive(false);
    }


    void Update()
    {

    }
    public void showColorRGB()
    {
        colorImage.Value = new Color(RValue.value, GValue.value, BValue.value);
        float R = change255Value(RValue.value);
        float G = change255Value(GValue.value);
        float B = change255Value(BValue.value);

        RValueText.text = R.ToString();
        GValueText.text = G.ToString();
        BValueText.text = B.ToString();
    }

    public void showColorHSV()
    {
        colorImage.Value = Color.HSVToRGB(HValue.value, SValue.value, VValue.value);
        HValueText.text = change360Value(HValue.value).ToString();
        SValueText.text = change100Value(SValue.value).ToString();
        VValueText.text = change100Value(VValue.value).ToString();

        RValueText.text = change255Value(colorImage.Value.r).ToString();
        GValueText.text = change255Value(colorImage.Value.g).ToString();
        BValueText.text = change255Value(colorImage.Value.b).ToString();

        RValue.value = colorImage.Value.r;
        GValue.value = colorImage.Value.g;
        BValue.value = colorImage.Value.b;
    }


    private int change360Value(float value)
    {
        return (int)(360 * value);
    }
    private int change255Value(float value)
    {
        return (int)(255 * value);
    }
    private int change100Value(float value)
    {
        return (int)(100 * value);
    }

    public void openPanel()
    {
        gameObject.SetActive(true);
    }
}
