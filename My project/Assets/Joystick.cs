using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    // �߰�
    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    private Vector2 inputVector;    // �߰�
    private bool isInput;    // �߰�

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
        //�߰�
        var clampedDir = inputDir.magnitude < leverRange ?
            inputDir : inputDir.normalized * leverRange;

        // lever.anchoredPosition = inputDir;
        lever.anchoredPosition = clampedDir;    // ����

        ControlJoystickLever(eventData);  // �߰�
        isInput = true;    // �߰�

    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        // �߰�
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;    // ����

        ControlJoystickLever(eventData);    // �߰�
        isInput = false;    // �߰�
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
        // ĳ���Ϳ��� �Էº��͸� ����
    }
}
