using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class changeImageColor : MonoBehaviour
{
    colorPallet pallet;
    [SerializeField]
    Image image;
    private void Start()
    {
        pallet = GetComponent<colorPallet>();
        pallet.colorImage.Subscribe(_ => showColor());
    }
    private void showColor()
    {
        image.color = pallet.colorImage.Value;
    }
}
