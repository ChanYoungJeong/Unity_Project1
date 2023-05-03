using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOnTrigger : MonoBehaviour
{
    public GameObject pointer;
    //�����
    /* ���� ����ü�� PrefabOnTrigger��� �� ��ũ��Ʈ�� ����
     * InstatiatePrefab�� ���� ��ũ��Ʈ�� ������(����ü) ����Ʈ�� �߻�ü�� ����
     * �Ʒ� Impact ���� ����Ʈ ����
     * Impact������Ʈ�� PrefabOnTrigger,Collider, RigidBody�� �ִ´�.(�׷��� ���� �� ����Ʈ�� ���缭 �������� ��)
     * 
     * InstatiateToTarget�� createPrefabToTarget�� �ִϸ����� �̺�Ʈ�� �����ϰ�
     * Resource/Prefabs/Skills�� PrefabPointer(������) �� ������Ʈ�� �����ϸ� ��
     */
    public GameObject Impact;
    public float damage;

    //Pointer�� ���ÿ� ������ ���� �� �� �������� �����ϴ� ������ ����
    //���� ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pointer")
        {
            if (Impact != null)
            {
                GameObject impact = Instantiate(Impact, this.transform.position, this.transform.rotation);
                impact.GetComponent<PrefabOnTrigger>().damage = damage;
                Game_System.setParentHolder(impact.transform);
                Destroy(this.gameObject);
                Destroy(impact, 1);   //����Ŭ �ý����� Stop Action ������ Destroy�� �����ϸ� ����Ʈ�� ���� �� �ڵ����� �ı��˴ϴ�
                Destroy(collision.gameObject); //�Ϻη� �־� ���� �̴ϴ�. ���� �� �������
            }
        }
        
        //Destroy(gameObject);
    }
}

