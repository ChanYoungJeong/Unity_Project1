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
		transform.position = eventData.position;  //드래그 중 마우스를 따라다니게 하기.
        subcharimage = this.GetComponent<image>().sprite;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}