using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundVolume : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;

    [SerializeField]
    Image VolumeImage;

    [SerializeField]
    Slider VolumeSlider;

    private float Volume = 0.4f;
    void Start()
    {
        sound.volume = Volume;
    }
    public void volumeChange()
    {
        Volume = VolumeSlider.value * 0.4f;
        sound.volume = Volume;
        VolumeImage.fillAmount = VolumeSlider.value;
    }
}
