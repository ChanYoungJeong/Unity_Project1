using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] public int to;
    public void OnDrop(PointerEventData ped)
    {
        Drag dragged = ped.pointerDrag.GetComponent<Drag>();
        switch (dragged.from)
        {
            case 1:
                switch (to)
                {
                    case 1:
                        Destroy(dragged);
                        break;
                }
                break;
        }
        Debug.Log(string.Format("dragged {0} to {1}", dragged.from, to));
        dragged.SetOrgPos(GetComponent<RectTransform>().anchoredPosition3D);
    }
    void Start()
    {

    }
    void Update()
    {

    }
}