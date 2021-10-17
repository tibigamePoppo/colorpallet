using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonClick : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("‰¹‚ğ–Â‚ç‚µ‚Ä‚¢‚éB");
        SeManager.Instance.ShotSe(SeType.click);
    }
}
