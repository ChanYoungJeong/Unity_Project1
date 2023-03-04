using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;        //ui�� �ҼӵǾ� �ִ� �ֻ�� ĵ���� Ʈ������
    private Transform previousParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    private RectTransform rect;         //ui ��ġ ��� ����
    private CanvasGroup canvasGroup;    //ui�� ���İ��� ��ȣ�ۿ� ��� ���� ĵ���� �׷�

    public Transform SubChar;
    Sprite startSprite;
    Transform saveSubChar;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        startSprite = GetComponent<Image>().sprite;
        saveSubChar = SubChar;
        SubChar.gameObject.SetActive(false);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("���� : "+rect.position);

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

        if (transform.parent == canvas)
        {
            Debug.Log("��ġ ����%%%%%");
            // �������� �Ҽӵ��־��� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� �̵�
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
            Debug.Log("�� : " + rect.position);
            //GetComponent<Image>().sprite = startSprite;

        }
        else
        {
            if (transform.parent.name.Contains("Slot"))
            {
                Debug.Log("��ġ ����@@@@@");
                GetComponent<Image>().sprite = startSprite;
                rect.position = previousParent.GetComponent<RectTransform>().position;
                SubChar.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("��ġ �Ϸ�#####");
                SubChar.gameObject.SetActive(true);
                SubChar.transform.position = new Vector3(rect.position.x, rect.position.y - 0.8f, rect.position.z);

            }
        }


        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = true;
    }



}