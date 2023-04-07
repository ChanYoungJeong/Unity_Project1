using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubCoolTimeBar : MonoBehaviour
{
    public Slider barObj;
    private Stat stat;

    private float fillSpeed = 1f; //ä������ �ӵ� ������ ����
    public float currentValue = 0f; //���� ��

    private void Awake()
    {
        stat = GetComponent<Stat>();
    }

    private void Start()
    {
        barObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.6f,
                                                       this.transform.position.z);
    }

    private void Update()
    {
        currentValue += Time.deltaTime/stat.sub_skillCooldown;
        barObj.value = currentValue;
    }
}