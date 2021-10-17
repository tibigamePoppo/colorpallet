using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;

public class dragImage : MonoBehaviour,IBeginDragHandler,IDragHandler,IDropHandler,IEndDragHandler
{
    CMmode System;
    CanvasGroup group;
    [SerializeField]
    private int ImageNum;
    private Vector3 startPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.SetAsLastSibling();//�摜���őO�ʂɔz�u
        this.transform.position = Input.mousePosition;//�}�E�X�̈���W�𕡐������I�u�W�F�N�g�Ɋ��蓖�Ă�
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("�h���b�v���ꂽ");
        System.drag(ImageNum);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�h���b�v����");
        System.endDrag(ImageNum);
        group.blocksRaycasts = true;
    }

    void Start()
    {
        startPos = this.gameObject.transform.position;
        System = GameObject.Find("gameSystem").GetComponent<CMmode>();
        group = GetComponent<CanvasGroup>();
        System.round.Subscribe(_ => setPos());
    }

    private void setPos()
    {
        this.gameObject.transform.position = startPos;
    }
}
