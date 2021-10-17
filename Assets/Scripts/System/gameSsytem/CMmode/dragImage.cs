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
        this.transform.SetAsLastSibling();//画像を最前面に配置
        this.transform.position = Input.mousePosition;//マウスの一座標を複製したオブジェクトに割り当てる
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("ドロップされた");
        System.drag(ImageNum);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("ドロップした");
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
