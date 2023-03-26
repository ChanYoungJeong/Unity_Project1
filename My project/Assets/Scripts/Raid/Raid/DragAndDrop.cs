using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject temp;
    [SerializeField]
    private Transform canvas;        //ui�� �ҼӵǾ� �ִ� �ֻ�� ĵ���� Ʈ������
    [SerializeField]
    public Transform previousParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    public RectTransform previousRect;
    private RectTransform rect;         //ui ��ġ ��� ����
    private CanvasGroup canvasGroup;    //ui�� ���İ��� ��ȣ�ۿ� ��� ���� ĵ���� �׷�

    public Transform SubChar;
    Sprite startSprite;
    Vector3 mousePos;
    Vector3 point;

    private Image dragImage;

    private void Awake()
    {
        canvas = temp.transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startSprite = GetComponent<Image>().sprite;
        SubChar.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        // �巡�� ���� �ҼӵǾ� �ִ� �θ� Ʈ������ ���� ����
        previousParent = transform.parent;
        previousRect = transform.parent.GetComponent<RectTransform>();


        //���� �巡������ ui�� ȭ���� �ֻ�ܿ� ��µǵ��� �ϱ� ����
        transform.SetParent(canvas);    //�θ� ������Ʈ�� ĵ������ ����
                                        //�巡�� ������ ������Ʈ�� �ϳ��� �ƴ� �ڽĵ��� ������ ���� ���� �ֱ� ������ ĵ���� �׷����� ����
                                        //���İ��� 0.6���� �����ϰ�, ���� �浹ó���� ���� �ʵ��� ��
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Input.mousePosition;
        point = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z + 100));
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ����
        transform.position = point;
        transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //�巡�׸� ������ �� �θ� ������ �ƴ϶�� ���󺹱�
        if (!transform.parent.GetComponent<SlotUi>())
        {
            if (previousParent.name.Contains("Slot"))
            {
                // �������� �Ҽӵ��־��� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� �̵�
                transform.SetParent(previousParent);
                //rect.position = previousParent.GetComponent<RectTransform>().position;
                rect.position = transform.parent.position;
                canvasGroup.alpha = 1f;
            }
            else
            {
                transform.SetParent(previousParent);
                //rect.position = previousParent.GetComponent<RectTransform>().position;
                rect.position = transform.parent.position;
                canvasGroup.alpha = 0f;
            }
        }
        else
        {
            if (transform.parent.name.Contains("Slot"))
            {
                GetComponent<Image>().sprite = startSprite;
                rect.position = transform.parent.position;
                SubChar.gameObject.SetActive(false);
                canvasGroup.alpha = 1f;
            }
            else
            {
                SubChar.gameObject.SetActive(true);
                SubChar.transform.position = new Vector3(rect.position.x, rect.position.y - 0.8f, rect.position.z);
                canvasGroup.alpha = 0f;              
            }
        }
        canvasGroup.blocksRaycasts = true;
    }

    public void DragImage(Sprite _dragImage)
    {
        dragImage.sprite = _dragImage;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = dragImage.color;
        color.a = _alpha;
        dragImage.color = color;
    }

}