using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HSVmode : MonoBehaviour
{
    [SerializeField]
    private Image[] anserImages = null;
    private bool isInputButton;
    [SerializeField]
    private Text problemText = null;
    public ReactiveProperty<int> round = new ReactiveProperty<int>(0);
    private int correctAnswer;

    Text correctText;
    [SerializeField]
    spinImage spin;

    int answerHvalue;
    int answerSvalue;
    int answerVvalue;
    int answer;

    private GameObject result;
    private GameObject result_f;

    Color resultColor;
    randomImage Image;
    void Start()
    {
        isInputButton = true;
        correctAnswer = 0;
        result = GameObject.Find("result");
        result_f = GameObject.Find("result_f");
        correctText = GameObject.Find("correctText").GetComponent<Text>(); ;
        result.SetActive(false);
        result_f.SetActive(false);
        Image = GetComponent<randomImage>();
        makeProblem();
    }

    private void makeProblem()
    {
        round.Value++;
        answer = Random.Range(0, 4);
        Image.random(answer);

        for (int i = 0; i < 4; i++)
        {
            float Hvalue = Random.Range(0.0f, 1.0f);
            float Svalue = Random.Range(0.0f, 1.0f);
            float Vvalue = Random.Range(0.0f, 1.0f);
            anserImages[i].color = Color.HSVToRGB(Hvalue, Svalue, Vvalue);
            if (i == answer)
            {
                resultColor = Color.HSVToRGB(Hvalue, Svalue, Vvalue);
                answerHvalue = change360Value(Hvalue);
                answerSvalue = change100Value(Svalue);
                answerVvalue = change100Value(Vvalue);
            }
        }
        inputText();
    }

    private int change360Value(float value)
    {
        return (int)(360 * value);
    }
    private int change100Value(float value)
    {
        return (int)(100 * value);
    }

    private void inputText()
    {
        problemText.text = ("Hが" + answerHvalue + "でSが" + answerSvalue + "でVが" + answerVvalue + "の色ってなんじゃっけ？");
    }

    public void Onclick(int value)
    {
        if (isInputButton == false) return;
        isInputButton = false;
        if (value == answer)
        {
            StartCoroutine("sendResult", true);
            correctAnswer++;
        }
        else
        {
            StartCoroutine("sendResult", false);
        }
        if (round.Value == 10)
        {
            Debug.Log("ゲーム終了正解した数は" + correctAnswer);
        }
    }

    private IEnumerator sendResult(bool value)
    {
        spin.spin();
        result.GetComponent<result>().showReselt(value, resultColor);
        yield return new WaitForSeconds(1.2f);
        result.SetActive(true);
    }

    public void nextGame()
    {
        if (round.Value == 10)
        {
            StartCoroutine("soundPlaye");
            result_f.SetActive(true);
            correctText.text = correctAnswer.ToString();
        }
        else
        {
            result.SetActive(false);
            makeProblem();
        }
        isInputButton = true;
    }
    IEnumerator soundPlaye()
    {
        yield return new WaitForFixedUpdate();
        Debug.Log("result音を鳴らした");
        if (correctAnswer == 10) SeManager.Instance.ShotSe(SeType.perfect);
        else if (correctAnswer >= 3) SeManager.Instance.ShotSe(SeType.good);
        else SeManager.Instance.ShotSe(SeType.nogood);
    }

        public void reset()
    {
        round.Value = 0;
        correctAnswer = 0;
        makeProblem();
        result_f.SetActive(false);
        result.SetActive(false);
        isInputButton = true;
    }
}
