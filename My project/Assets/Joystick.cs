using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    // 추가
    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    private Vector2 inputVector;    // 추가
    private bool isInput;    // 추가

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        //추가
        var clampedDir = inputDir.magnitude < leverRange ?
            inputDir : inputDir.normalized * leverRange;

        // lever.anchoredPosition = inputDir;
        lever.anchoredPosition = clampedDir;    // 변경

        ControlJoystickLever(eventData);  // 추가
        isInput = true;    // 추가

    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        // 추가
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;    // 변경

        ControlJoystickLever(eventData);    // 추가
        isInput = false;    // 추가
    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
        inputVector = clampedDir / leverRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
    }

    private void InputControlVector()
    {
        //Debug.Log(inputDirection.x + " / " + inputDirection.y);
        // 캐릭터에게 입력벡터를 전달
    }
}
