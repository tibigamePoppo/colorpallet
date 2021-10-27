
using UnityEngine;
using DG.Tweening;

public class PopUp : MonoBehaviour
{
    private void OnEnable()
    {
        Tweener tweener = null;

        // 再生中のアニメーションを停止/初期化
        if (tweener != null)
        {
            tweener.Kill();
            transform.localScale = Vector3.one;
        }
        tweener = transform.DOPunchScale(
            punch: Vector3.one * 0.1f,
            duration: 1f,
            vibrato: 1
        ).SetEase(Ease.OutExpo);
    }
}
