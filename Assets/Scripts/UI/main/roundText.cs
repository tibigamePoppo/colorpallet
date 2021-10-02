using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class roundText : MonoBehaviour
{
    HSVmode HSV;
    RGBmode RGB;
    TAmode TA;
    CMmode CM;
    Text text;
    private enum Mode 
    {
        HSV,
        RGB,
        TA,
        CM
    }
    [SerializeField]
    Mode mode;
    void Start()
    {
        text = GetComponent<Text>();

        if (mode == Mode.HSV)
        {
            HSV = GameObject.Find("gameSystem").GetComponent<HSVmode>();
            HSV.round.Subscribe(round => showText(round));
        }
        else if (mode == Mode.RGB)
        {
            RGB = GameObject.Find("gameSystem").GetComponent<RGBmode>();
            RGB.round.Subscribe(round => showText(round));
        }
        else if (mode == Mode.TA)
        {
            TA = GameObject.Find("gameSystem").GetComponent<TAmode>();
            TA.correctAnswer.Subscribe(correctAnswer => showText(correctAnswer));
        }
        else if (mode == Mode.CM)
        {
            CM = GameObject.Find("gameSystem").GetComponent<CMmode>();
            CM.round.Subscribe(correctAnswer => showText(correctAnswer));
        }
    }

    private void showText(int round)
    {
        text.text = round + "/10";
    }
}
