using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    private Transform canvas;        //ui가 소속되어 있는 최상단 캔버스 트랜스폼
    private Transform previousParent; // 해당 오브젝트가 직전에 소속되어 있었던 부모
    private RectTransform rect;         //ui 위치 제어를 위한
    private CanvasGroup canvasGroup;    //ui가 알파값과 상호작용 제어를 위한 캔버스 그룹

    public GameObject SubChar;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 직전 소속되어 있던 부모 트랜스폼 정보 저장

        previousParent = transform.parent;

        //현재 드래그중인 ui가 화면의 최상단에 출력되도록 하기 위해
        transform.SetParent(canvas);    //부모 오브젝트를 캔버스로 설정
        transform.SetAsLastSibling();   //가장 앞에 보이도록 마지막 자식으로 설정

        //드래그 가능한 오브젝트가 하나가 아닌 자식들을 가지고 있을 수도 있기 때문에 캔버스 그룹으로 통제
        //알파값을 0.6으로 설정하고, 광선 충돌처리가 되지 않도록 함
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) 
    {
        // 현재 스크린상의 마우스 위치를 UI 위치로 설정
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //드래그 시작하면 부모가 캔버스로 설정되기 때문에
        //드래그를 종료할 때 부모가 캔버스이면 엉뚱한 곳에 드롭을 했기에 직전에 소속되 있던 슬롯으로 이동

        if(transform.parent == canvas)
        {
            // 마지막에 소속되있었던 previousParent의 자식으로 설정하고, 해당 위치로 이동
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
            SubChar.transform.position = previousParent.GetComponent<RectTransform>().position;
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }

}