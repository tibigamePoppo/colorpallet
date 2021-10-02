using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj = null;
    public void Onclick()
    {
        targetObj.SetActive(false);
    }
}
