using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

namespace nkjzm
{
    /// <summary>
    /// �|�b�v�ɉ������{�^��
    /// </summary>
    public class PopButton : Button
    {
        Tweener tweener = null;
        new void Start()
        {
            base.Start();

            // �{�^���A�j���[�V����
            onClick.AddListener(() =>
            {
                // �Đ����̃A�j���[�V�������~/������
                if (tweener != null)
                {
                    tweener.Kill();
                    tweener = null;
                    transform.localScale = Vector3.one;
                }
                tweener = transform.DOPunchScale(
                    punch: Vector3.one * 0.1f,
                    duration: 1f,
                    vibrato: 1
                ).SetEase(Ease.OutExpo);
            });
        }
    }
}