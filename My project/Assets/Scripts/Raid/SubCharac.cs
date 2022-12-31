using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubCharac : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    public static subcharimage;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;  //�巡�� �� ���콺�� ����ٴϰ� �ϱ�.
        subcharimage = this.GetComponent<image>().sprite;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}