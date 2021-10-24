using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeWIndow : MonoBehaviour
{
    [SerializeField]
    private GameObject[] windows;

    public void Onclick()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
    }
}
