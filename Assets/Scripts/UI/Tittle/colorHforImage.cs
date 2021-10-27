using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorHforImage : MonoBehaviour
{
    [SerializeField]
    Image Hbar;
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void OnChange()
    {
        Hbar.color = Color.HSVToRGB(slider.value, 1, 1);
    }
}
