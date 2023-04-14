using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiateToTarget : MonoBehaviour
{
    [SerializeField]
    Transform TargetObject;
    Transform target;

    Vector3 TargetPosition;
    [SerializeField]
    float x;
    [SerializeField]
    float y;

    GameObject prefabObject;
    private Stat stat;
    void Start()
    {
        stat = GetComponentInParent<Stat>();


        if (!TargetObject) return;
        getTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Battle_Situation_Trigger.monster) return;

        if (!TargetObject)
        {
            target = Battle_Situation_Trigger.monster ?
            Battle_Situation_Trigger.monster.transform : CreateBoss.Bss.transform;
        }
    }

    void getTarget()
    {
        TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
    }

    void createPrefab(GameObject prefab)
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

    }

    void Ligntning(GameObject prefab)
    {
        GameObject prefabClone = Instantiate(prefab, target.position, Quaternion.identity);
    }
}
