using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TAmode : MonoBehaviour
{
    [SerializeField]
    private Image[] anserImages = null;
    [SerializeField]
    private Text problemText = null;
    public ReactiveProperty<int> correctAnswer = new ReactiveProperty<int>(0);
    private int FailureAnswer;

    Text correctText;

    int answerRvalue;
    int answerGvalue;
    int answerBvalue;
    int answerHvalue;
    int answerSvalue;
    int answerVvalue;
    int answer;

    int time;

    private GameObject result;
    private GameObject result_f;
    private GameObject result_x;

    Color resultColor;
    randomImage Image;
    void Start()
    {
        time = 0;
        FailureAnswer = 0;
        result = GameObject.Find("result");
        result_f = GameObject.Find("result_f");
        result_x = GameObject.Find("result_x");
        correctText = GameObject.Find("correctText").GetComponent<Text>(); ;
        result.SetActive(false);
        result_f.SetActive(false);
        result_x.SetActive(false);
        Image = GetComponent<randomImage>();
        makeProblem();
        StartCoroutine("timeCount");
    }

    private void makeProblem()
    {
        int Switch = Random.Range(0,2);
        if (Switch == 1) makeProblemRGB();
        else makeProblemHSV();
    }

    private void makeProblemRGB()
    {
        Image.Start();
        answer = Random.Range(0, 4);

        for (int i = 0; i < 4; i++)
        {
            float Rvalue = Random.Range(0.0f, 1.0f);
            float Gvalue = Random.Range(0.0f, 1.0f);
            float Bvalue = Random.Range(0.0f, 1.0f);
            anserImages[i].color = new Color(Rvalue, Gvalue, Bvalue, 1);
            if (i == answer)
            {
                resultColor = new Color(Rvalue, Gvalue, Bvalue, 1);
                answerRvalue = change255Value(Rvalue);
                answerGvalue = change255Value(Gvalue);
                answerBvalue = change255Value(Bvalue);
            }
        }
        inputTextRGB();
    }
    private void makeProblemHSV()
    {
        Image.Start();
        answer = Random.Range(0, 4);

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
        inputTextHSV();
    }
    private int change360Value(float value)
    {
        return (int)(360 * value);
    }
    private int change255Value(float value)
    {
        return (int)(255 * value);
    }
    private int change100Value(float value)
    {
        return (int)(100 * value);
    }

    private void inputTextRGB()
    {
        problemText.text = ("Rが" + answerRvalue + "でGが" + answerGvalue + "でBが" + answerBvalue + "の色ってなんじゃったっけ？");
    }
    private void inputTextHSV()
    {
        problemText.text = ("Hが" + answerHvalue + "でSが" + answerSvalue + "でVが" + answerVvalue + "の色ってなんじゃったっけ？");
    }

    public void Onclick(int value)
    {
        if (value == answer)
        {
            sendResult(true);
            correctAnswer.Value++;
        }
        else
        {
            sendResult(false);
        }
    }

    private void sendResult(bool value)
    {
        result.SetActive(true);
        result.GetComponent<result>().showReselt(value, resultColor);
        if (value == false) FailureAnswer++;
    }

    public void nextGame()
    {
        if (correctAnswer.Value == 10)
        {
            result_f.SetActive(true);
            StopCoroutine("timeCount");
            ranking(time);
            correctText.text = time.ToString();
        }
        else if (FailureAnswer == 3)
        {
            result_x.SetActive(true);
            StopCoroutine("timeCount");
        }
        else
        {
            result.SetActive(false);
            makeProblem();
        }
    }

    public void reset()
    {
        correctAnswer.Value = 0;
        FailureAnswer = 0;
        time = 0;
        makeProblem();
        result_f.SetActive(false);
        result.SetActive(false);
        result_x.SetActive(false);
    }

    IEnumerator timeCount()
    {
        yield return new WaitForSeconds(1f);
        time++;
        StartCoroutine("timeCount");
    }

    private void ranking(int time)
    {
        int temp;//一時的な数字
        int rank3 = PlayerPrefs.GetInt("SDrank3");
        if (rank3 < time)
        {
            rank3 = time;
            int rank2 = PlayerPrefs.GetInt("SDrank2");
            if (rank2 < rank3)
            {
                temp = rank2;
                rank2 = rank3;
                rank3 = temp;
                int rank1 = PlayerPrefs.GetInt("SDrank1");
                if (rank1 < rank2)
                {
                    temp = rank1;
                    rank1 = rank2;
                    rank2 = temp;
                    PlayerPrefs.SetInt("SDrank1", rank1);
                }
                PlayerPrefs.SetInt("SDrank2", rank2);
            }
            PlayerPrefs.SetInt("SDrank3", rank3);
        }
    }
}
