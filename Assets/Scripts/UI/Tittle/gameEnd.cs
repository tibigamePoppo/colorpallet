using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace title
{
    public class gameEnd : MonoBehaviour
    {
        public void OnClick()//ゲームを終了する
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//Unity上の場合、再生を停止する
#else
		Application.Quit();//そのほかの場合、ゲームを終了する
#endif
        }
    }
}