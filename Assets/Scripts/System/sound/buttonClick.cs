using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("音を鳴らしている。");
        SeManager.Instance.ShotSe(SeType.click);
    }
}
