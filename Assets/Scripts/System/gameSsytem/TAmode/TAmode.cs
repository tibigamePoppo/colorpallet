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
    private bool isInputButton;
    public ReactiveProperty<int> correctAnswer = new ReactiveProperty<int>(0);
    public ReactiveProperty<int> round = new ReactiveProperty<int>(0);
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
    [SerializeField]
    spinImage spin;

    Color resultColor;
    randomImage Image;
    void Start()
    {
        isInputButton = true;
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
        round.Value++;
        answer = Random.Range(0, 4);
        Image.random(answer);

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
        if (isInputButton == false) return;
        isInputButton = false;
        if (value == answer)
        {
            StartCoroutine("sendResult", true);
            correctAnswer.Value++;
        }
        else
        {
            StartCoroutine("sendResult", false);
        }
    }

    private IEnumerator sendResult(bool value)
    {
        spin.spin();
        result.GetComponent<result>().showReselt(value, resultColor);
        yield return new WaitForSeconds(1.2f);
        result.SetActive(true);
        if (value == false) FailureAnswer++;
    }

    public void nextGame()
    {
        if (correctAnswer.Value == 10)
        {
            StartCoroutine("soundPlaye");
            StopCoroutine("timeCount");
            ranking(time);
            correctText.text = time.ToString();
            result_f.SetActive(true);
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
        isInputButton = true;
    }
    IEnumerator soundPlaye()
    {
        yield return new WaitForFixedUpdate();
        Debug.Log("result音を鳴らした");
        if (FailureAnswer == 0) SeManager.Instance.ShotSe(SeType.perfect);
        else SeManager.Instance.ShotSe(SeType.good);
    }

    public void reset()
    {
        round.Value = 0;
        correctAnswer.Value = 0;
        FailureAnswer = 0;
        time = 0;
        makeProblem();
        result_f.SetActive(false);
        result.SetActive(false);
        result_x.SetActive(false);
        isInputButton = true;
    }

    IEnumerator timeCount()
    {
        Debug.Log(time);
        yield return new WaitForSeconds(1f);
        time++;
        StartCoroutine("timeCount");
    }

    private void ranking(int time)
    {
        int temp;//一時的な数字
        int rank3 = PlayerPrefs.GetInt("TArank3");
        if (rank3 < time)
        {
            rank3 = time;
            int rank2 = PlayerPrefs.GetInt("TArank2");
            if (rank2 < rank3)
            {
                temp = rank2;
                rank2 = rank3;
                rank3 = temp;
                int rank1 = PlayerPrefs.GetInt("TArank1");
                if (rank1 < rank2)
                {
                    temp = rank1;
                    rank1 = rank2;
                    rank2 = temp;
                    PlayerPrefs.SetInt("TArank1", rank1);
                }
                PlayerPrefs.SetInt("TArank2", rank2);
            }
            PlayerPrefs.SetInt("TArank3", rank3);
        }
    }
}
