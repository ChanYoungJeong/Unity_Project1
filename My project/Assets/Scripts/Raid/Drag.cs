using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] public int from;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 org_pos;

    public void OnBeginDrag(PointerEventData ped)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.7f;
    }
    public void OnDrag(PointerEventData ped)
    {
        rectTransform.anchoredPosition += ped.delta;
    }
    public void OnEndDrag(PointerEventData ped)
    {
        rectTransform.anchoredPosition = org_pos;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;
    }
    public void SetOrgPos(Vector3 new_pos)
    {
        org_pos = new_pos;
    }
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        org_pos = rectTransform.anchoredPosition;
    }
    void Update()
    {

    }
}