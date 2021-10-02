using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingSystem : MonoBehaviour
{
    [SerializeField]
    private Text TAranking = null;
    [SerializeField]
    private Text SDranking = null;
    void Start()
    {
        int TArank1 = PlayerPrefs.GetInt("TArank1", 0);
        int TArank2 = PlayerPrefs.GetInt("TArank2", 0);
        int TArank3 = PlayerPrefs.GetInt("TArank3", 0);
        TAranking.text = "タイムアタックチャレンジ\n" + TArank1 + "\n" + TArank2 + "\n" + TArank3;
        int SDrank1 = PlayerPrefs.GetInt("SDrank1", 0);
        int SDrank2 = PlayerPrefs.GetInt("SDrank2", 0);
        int SDrank3 = PlayerPrefs.GetInt("SDrank3", 0);
        SDranking.text = "ノーミスチャレンジ\n" + SDrank1 + "\n" + SDrank2 + "\n" + SDrank3;
    }

    public void rankingReset()
    {
        PlayerPrefs.SetInt("TArank1", 0);
        PlayerPrefs.SetInt("TArank2", 0);
        PlayerPrefs.SetInt("TArank3", 0);
        PlayerPrefs.SetInt("SDrank1", 0);
        PlayerPrefs.SetInt("SDrank2", 0);
        PlayerPrefs.SetInt("SDrank3", 0);
        Start();
    }



}
