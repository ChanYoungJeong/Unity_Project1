using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubSlot : MonoBehaviour, IDropHandler
{
    public Image SlotImage;
    private RectTransform rect;
    //private Transform setTrasform;
    public float SlotCharAtkDmg;
    GameObject createObject;
    Vector3 vec = new Vector3(14.97f, -4.47f);

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        //setTrasform.position = vec;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            this.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<SubCharac>().CharImage.sprite;
            SlotCharAtkDmg = eventData.pointerDrag.GetComponent<SubCharac>().AtkDmg;
            createObject = Instantiate(eventData.pointerDrag.GetComponent<SubCharac>().thisObject, transform.position, transform.rotation);
            createObject.transform.SetParent(this.gameObject.transform);
            //Destroy(gameObject);    
        }
    }
}

