using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class spinImage : MonoBehaviour
{
    Animator ani;
    HSVmode HSV;
    RGBmode RGB;
    TAmode TA;
    SDmode SD;
    CMmode CM;
    private enum Mode
    {
        HSV,
        RGB,
        TA,
        SD,
        CM,
    }
    [SerializeField]
    Mode mode;
    void Start()
    {
        ani = GetComponent<Animator>();
        if (mode == Mode.HSV)
        {
            HSV = GameObject.Find("gameSystem").GetComponent<HSVmode>();
            HSV.round.Subscribe(_ => spin());
        }
        else if (mode == Mode.RGB)
        {
            RGB = GameObject.Find("gameSystem").GetComponent<RGBmode>();
            RGB.round.Subscribe(_ => spin());
        }
        else if (mode == Mode.TA)
        {
            TA = GameObject.Find("gameSystem").GetComponent<TAmode>();
            TA.round.Subscribe(_ => spin());
        }
        else if (mode == Mode.SD)
        {
            SD = GameObject.Find("gameSystem").GetComponent<SDmode>();
            SD.round.Subscribe(_ => spin());
        }
        else if (mode == Mode.CM)
        {
            CM = GameObject.Find("gameSystem").GetComponent<CMmode>();
            CM.round.Subscribe(_ => spin());
        }
        this.gameObject.SetActive(false);
    }

    private void spin()
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
