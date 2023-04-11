using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateToTarget : MonoBehaviour
{
    [SerializeField]
    Transform TargetObject;

    Vector3 TargetPosition;
    [SerializeField]
    float x;
    [SerializeField]
    float y;

    GameObject prefabObject;
    private Stat stat;
    void Start()
    {
        getTarget();
        stat = GetComponentInParent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {

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

    //���� �������� �� �ϱ�
    void setHeal()
    {
        if(prefabObject.GetComponent<Heal>())
            prefabObject.GetComponent<Heal>().healAmount = stat.atkDamage;
    }

    //���Ŀ� Heal���� �ٸ� ������ ��ũ��Ʈ ���� ����Ұ�
    void setDamage()
    {

    }
}
