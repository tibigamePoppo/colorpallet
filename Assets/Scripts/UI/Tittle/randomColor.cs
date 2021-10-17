using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomColor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] group = null;
    [SerializeField]
    private Image[] colorBall = null;
    [SerializeField]
    private string[] colorCode = null;
    private bool nextColor;
    void Start()
    {
        nextColor = false;
        StartCoroutine("changeColor");
        StartCoroutine("changeGroup"); 
        group[0].SetActive(false);
        group[1].SetActive(false);
        group[2].SetActive(false);
    }

    IEnumerator changeGroup()
    {
        group[0].SetActive(true);
        group[1].SetActive(false);
        group[2].SetActive(false);
        yield return new WaitUntil(() => nextColor == true);
        nextColor = false;
        group[0].SetActive(false);
        group[1].SetActive(true);
        group[2].SetActive(false);
        yield return new WaitUntil(() => nextColor == true);
        nextColor = false;
        group[0].SetActive(false);
        group[1].SetActive(false);
        group[2].SetActive(true);
        yield return new WaitUntil(() => nextColor == true);
        nextColor = false;
        StartCoroutine("changeGroup");
    }

    IEnumerator changeColor()
    {
        for (int i = 0; i < colorBall.Length; i++)
        {
            StartCoroutine("fadeColor", colorBall[i]);
        }
        yield return new WaitForSeconds(6f);
        StartCoroutine("changeColor");
    }

    IEnumerator fadeColor(Image target)
    {
        Color thisColor = target.color;
        for (int i = 1; i < 100; i++)
        {
            thisColor.a= thisColor.a -0.01f;
            target.color = thisColor;
            yield return new WaitForFixedUpdate();
        }
        nextColor = true;

        target.color = random();
        thisColor = target.color;
        thisColor.a = 0;
        target.color = thisColor;

        for (int i = 0; i < 100; i++)
        {
            thisColor.a = thisColor.a + 0.01f;
            target.color = thisColor;
            yield return new WaitForFixedUpdate();
        }
    }

    private Color random()
    {
        int RandomInt = Random.Range(0, colorCode.Length);
        Color color;
        ColorUtility.TryParseHtmlString(colorCode[RandomInt], out color);
        return color;
    }
}
