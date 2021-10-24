using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorSlider : MonoBehaviour
{
    [SerializeField]
    Image TargetImage;
    public void OnChangeValue()
    {
        TargetImage.fillAmount = GetComponent<Slider>().value;
    }
}
