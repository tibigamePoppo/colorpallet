using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomImage : MonoBehaviour
{
    [SerializeField]
    private Sprite[] Images = null;
    [SerializeField]
    private Image answerImage = null;

    [SerializeField]
    private Image[] targetImageObject = null;
    public void random(int answer)
    {
        for (int i = 0; i < targetImageObject.Length; i++)
        {
            int randomValue = Random.Range(0, Images.Length);
            targetImageObject[i].sprite = Images[randomValue];
            if(i == answer) answerImage.sprite = Images[randomValue];
        }
    }
}
