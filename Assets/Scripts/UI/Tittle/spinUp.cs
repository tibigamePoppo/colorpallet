using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class spinUp : MonoBehaviour
{

    private void OnEnable()
    {
        Tweener tweener = null;

        // �Đ����̃A�j���[�V�������~/������
        if (tweener != null)
        {
            tweener.Kill();
        }
        this.transform.DORotate(Vector3.up * 360f, 1f);
    }
}
