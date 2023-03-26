using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUi : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;
    private Color startColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        startColor = image.color;
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.gray;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = startColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        //pointerDrag�� ���� �巡�� �ϰ� �ִ� ���
        if (eventData.pointerDrag != null)
        {
            // �巡���ϰ� �ִ� ����� �θ� ���� ������Ʈ�� �����ϰ� ��ġ�� ������Ʈ ��ġ�� �����ϰ� ����
            if (transform.childCount == 0)
            {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>();
                /*
                transform.GetChild(0).parent = eventData.pointerDrag.GetComponent<DragAndDrop>().previousParent;
                transform.GetChild(0).GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<DragAndDrop>().previousRect.position;

                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                */

            }

        }
    }
}