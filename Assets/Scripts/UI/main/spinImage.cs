using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class spinImage : MonoBehaviour
{
    Animator ani;
    public void Start()
    {
        ani = GetComponent<Animator>();
        this.gameObject.SetActive(false);
    }

    public void spin()
    {
        this.gameObject.SetActive(true);
        ani.SetTrigger("spin");
        StartCoroutine("setfalse");
    }

    IEnumerator setfalse()
    {
        yield return new WaitForSeconds(1.2f);
        this.gameObject.SetActive(false);
    }
}
