using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnTrigger : MonoBehaviour
{
    [SerializeField]
    private bool multiHit;          //�ټ��� �������
    [SerializeField]
    //Color ���� ������ ���ּ�, ĳ���� ���ݿ��� �޾ƿ��ų� ���� �����ؼ� ������ ������ �ٲ�
    Color damageColor;

    [SerializeField] float destroytime;
    Monster_Combat monsterCombat;
    public float damage;
    private bool hitted = false;

    public GameObject Impact;
    private void Awake()
    {
        Game_System.setParentHolder(this.transform);
        hitted = false;
    }

    private void Update()
    {
        if (!Battle_Situation_Trigger.monster)
        {
            Destroy(this.gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //monsterCombat = Battle_Situation_Trigger.monster.GetComponent<Monster_Combat>();
        //�� ó���ҽ� �ٸ� ������ Ʈ���Ÿ� ���� �浹ü���� ������ �ȵ�
        //���� ���󰡴� ���� ���Ͱ� ������ �������� �ȵ�
        //�׷��� ������ �浹�ϴ� ���͸� �ٷ� ���ҽ�ų �ʿ䰡 ����
        if (collision.transform.GetComponent<Monster_Script>())
        {
            //������ ���� ���
            if (multiHit)
            {
                //�浹�ϴ� ��� ������Ʈ ������ ����
                monsterCombat = collision.transform.GetComponent<Monster_Combat>();
                monsterCombat.ApplyDamage(damage, damageColor, 0, 0);
                Destroy(this.gameObject, 3f);
            }
            //�ϳ��� �������
            if (!multiHit && !hitted)
            {
                //Ÿ�ٸ� ����
                hitted = true;
                monsterCombat = collision.transform.GetComponent<Monster_Combat>();
                monsterCombat.ApplyDamage(damage, damageColor, 0, 0);
                Destroy(this.gameObject, destroytime);
            }

            if (Impact != null)
            {
                GameObject impact = Instantiate(Impact, this.transform.position, this.transform.rotation);
                Game_System.setParentHolder(impact.transform);
                Destroy(impact, 1);
            }

        }

        if (collision.transform.GetComponent<BossScript>())
        {
            monsterCombat = collision.transform.GetComponent<Monster_Combat>();
            monsterCombat.ApplyDamage(damage, damageColor, 0, 0);
            Destroy(this.gameObject, destroytime);
        }
    }

    void AnimationEnd()
    {
        Destroy(gameObject);
    }


}
