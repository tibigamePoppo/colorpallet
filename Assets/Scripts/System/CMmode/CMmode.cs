using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CMmode : MonoBehaviour
{
    [SerializeField]
    private Image[] anserImages = null;
    [SerializeField]
    private Text problemText = null;
    public ReactiveProperty<int> round = new ReactiveProperty<int>(0);
    private int correctAnswer;

    Text correctText;

    int answerRvalue;
    int answerGvalue;
    int answerBvalue;
    int answer1;
    int answer2;

    int selectAnswer1;
    int selectAnswer2;

    private GameObject result;
    private GameObject result_f;

    Color resultColor;
    randomImage Image;
    void Start()
    {
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
        Image.Start();
        makeAnswer();
        answerRvalue = 0;
        answerGvalue = 0;
        answerBvalue = 0;
        for (int i = 0; i < 4; i++)
        {
            float Rvalue = Random.Range(0.0f, 1.0f);
            float Gvalue = Random.Range(0.0f, 1.0f);
            float Bvalue = Random.Range(0.0f, 1.0f);

            anserImages[i].color = new Color(Rvalue, Gvalue, Bvalue, 1);
            if (i == answer1 || i == answer2)
            {
                resultColor = new Color(Rvalue, Gvalue, Bvalue, 1);
                answerRvalue += change255Value(Rvalue);
                answerGvalue += change255Value(Gvalue);
                answerBvalue += change255Value(Bvalue);

            }
        }
        if (answerRvalue >= 256 || answerGvalue >= 256 || answerBvalue >= 256)
        {
            makeProblem();
            return;
        }
        round.Value++;
        inputText();

    }

    private void makeAnswer()
    {

        answer1 = Random.Range(0, 4);
        answer2 = Random.Range(0, 4);
        if (answer1 == answer2) makeAnswer();
    }

    private int change255Value(float value)
    {
        return (int)(255 * value);
    }

    private void inputText()
    {
        problemText.text = ("Rが" + answerRvalue + "でGが" + answerGvalue + "でBが" + answerBvalue + "の色ってなんじゃったっけ？");
    }

    private void checkResult()
    {
        if (selectAnswer1 == answer1 || selectAnswer1 == answer2)
        {
            if (selectAnswer2 == answer1 || selectAnswer2 == answer2)
            {
                sendResult(true);
                correctAnswer++;
            }
        }
        else
        {
            sendResult(false);
        }
        if (round.Value == 10)
        {
            Debug.Log("ゲーム終了正解した数は" + correctAnswer);
        }
    }

    private void sendResult(bool value)
    {
        result.SetActive(true);
        result.GetComponent<result>().showReselt(value, resultColor);
    }

    public void nextGame()
    {
        if (round.Value == 10)
        {
            result_f.SetActive(true);
            correctText.text = correctAnswer.ToString();
        }
        else
        {
            result.SetActive(false);
            makeProblem();
        }
    }

    public void reset()
    {
        round.Value = 0;
        correctAnswer = 0;
        makeProblem();
        result_f.SetActive(false);
        result.SetActive(false);
    }

    public void drag(int i)
    {
        selectAnswer2 = i;
        checkResult();
    }

    public void endDrag(int i)
    {
        selectAnswer1 = i;
    }
}
