using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnTrigger : MonoBehaviour
{
    [SerializeField]
    private bool multiHit;          //다수를 때릴경우
    [SerializeField]
    //Color 또한 변수로 나둬서, 캐릭터 스텟에서 받아오거나 직접 설정해서 데미지 색상을 바꿈
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
        //로 처리할시 다른 곳에서 트리거를 사용시 충돌체에게 적용이 안됨
        //또한 날라가는 도중 몬스터가 죽을시 데미지가 안들어감
        //그렇기 때문에 충돌하는 몬스터를 바로 감소시킬 필요가 있음
        if (collision.transform.GetComponent<Monster_Script>())
        {
            //여러명 때릴 경우
            if (multiHit)
            {
                //충돌하는 모든 오브젝트 데미지 적용
                monsterCombat = collision.transform.GetComponent<Monster_Combat>();
                monsterCombat.ApplyDamage(damage, damageColor, 0, 0);
                Destroy(this.gameObject, 3f);
            }
            //하나만 때릴경우
            if (!multiHit && !hitted)
            {
                //타겟만 적용
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
