using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{
    public void OnClick()
    {
        SeManager.Instance.ShotSe(SeType.click);
    }
}
