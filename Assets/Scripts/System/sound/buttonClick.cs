using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("����炵�Ă���B");
        SeManager.Instance.ShotSe(SeType.click);
    }
}
