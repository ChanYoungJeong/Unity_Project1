using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private Transform canvas;        //ui�� �ҼӵǾ� �ִ� �ֻ�� ĵ���� Ʈ������
    private Transform previousParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    private RectTransform rect;         //ui ��ġ ��� ����
    private CanvasGroup canvasGroup;    //ui�� ���İ��� ��ȣ�ۿ� ��� ���� ĵ���� �׷�

    public GameObject SubChar;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ���� �ҼӵǾ� �ִ� �θ� Ʈ������ ���� ����

        previousParent = transform.parent;

        //���� �巡������ ui�� ȭ���� �ֻ�ܿ� ��µǵ��� �ϱ� ����
        transform.SetParent(canvas);    //�θ� ������Ʈ�� ĵ������ ����
        transform.SetAsLastSibling();   //���� �տ� ���̵��� ������ �ڽ����� ����

        //�巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ ���� ���� �ֱ� ������ ĵ���� �׷����� ����
        //���İ��� 0.6���� �����ϰ�, ���� �浹ó���� ���� �ʵ��� ��
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ����
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�� �����ϸ� �θ� ĵ������ �����Ǳ� ������
        //�巡�׸� ������ �� �θ� ĵ�����̸� ������ ���� ����� �߱⿡ ������ �Ҽӵ� �ִ� �������� �̵�

        if(transform.parent == canvas)
        {
            // �������� �Ҽӵ��־��� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� �̵�
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
            SubChar.transform.position = previousParent.GetComponent<RectTransform>().position;
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

}