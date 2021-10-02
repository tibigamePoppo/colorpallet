using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expanel : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        this.gameObject.SetActive(true);
        StartCoroutine("False");
    }

    IEnumerator False()
    {
        yield return new WaitUntil(() => Input.anyKey);
        this.gameObject.SetActive(false);
    }
}
