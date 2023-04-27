using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiateToTarget : MonoBehaviour
{
    [Header("타겟이 정적일 시 넣기/아닐시 빈칸으로")]
    [SerializeField]
    Transform TargetObject;
    bool hasSelectedTarget;

    Vector3 TargetPosition;
    [Header("타겟을 기준으로 x,y 축 조정값")]
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

    void createPrefabByTarget(GameObject prefab)
    {
        prefabObject = Instantiate(prefab, TargetPosition , Quaternion.identity);
        setHeal();
        setDamage();
    }

    //힐이 있을경우는 힐 하기
    void setHeal()
    {
        if(prefabObject.GetComponent<Heal>())
            prefabObject.GetComponent<Heal>().healAmount = stat.atkDamage;
    }

    //추후에 Heal말고 다른 데미지 스크립트 사용시 사용할것
    void setDamage()
    {
        if (prefabObject.GetComponent<PrefabOnTrigger>())
            prefabObject.GetComponent<PrefabOnTrigger>().damage = stat.skillDamage;
    }
}
