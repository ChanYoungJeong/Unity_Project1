using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubCharac : MonoBehaviour, IDragHandler,IBeginDragHandler, IEndDragHandler
{
    public Canvas SubCanvas;
    public Image CharImage;
    public GameObject thisObject;
    private RectTransform rectTransform;
    public float AtkDmg;

    private void Awake()
    {
        AtkDmg = 10;
        CharImage = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    //public static subcharimage;
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(SubCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
	{
        Vector3 vec = Camera.main.WorldToScreenPoint(rectTransform.position);
        vec.x += eventData.delta.x;
        vec.y += eventData.delta.y;
        rectTransform.position = Camera.main.ScreenToWorldPoint(vec);
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}