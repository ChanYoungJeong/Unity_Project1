using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiateToTarget : MonoBehaviour
{
    [Header("Ÿ���� ������ �� �ֱ�/�ƴҽ� ��ĭ����")]
    [SerializeField]
    Transform TargetObject;
    bool hasSelectedTarget;

    Vector3 TargetPosition;
    [Header("Ÿ���� �������� x,y �� ������")]
    [SerializeField]
    float x;
    [SerializeField]
    float y;

    GameObject prefabObject;
    private Stat stat;

    private float angle;
    void Start()
    {
        stat = GetComponentInParent<Stat>();


        if (TargetObject)
        setTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Battle_Situation_Trigger.monster) return;

        if (!hasSelectedTarget)
        {
            TargetObject = Battle_Situation_Trigger.monster ?
            Battle_Situation_Trigger.monster.transform : CreateBoss.Bss.transform;
            TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
        }
    }

    void setTarget()
    {
        TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
        hasSelectedTarget = true;
    }

    void createPrefabToTarget(GameObject prefab)
    {
        prefabObject = Instantiate(prefab, TargetPosition , Quaternion.identity);
        setHeal();
        setDamage();
    }

    //���� �������� �� �ϱ�
    void setHeal()
    {
        if(prefabObject.GetComponent<Heal>())
            prefabObject.GetComponent<Heal>().healAmount = stat.atkDamage;
    }

    //���Ŀ� Heal���� �ٸ� ������ ��ũ��Ʈ ���� ����Ұ�
    void setDamage()
    {
        if (prefabObject.GetComponent<PrefabOnTrigger>())
            prefabObject.GetComponent<PrefabOnTrigger>().damage = stat.skillDamage;
    }
}
