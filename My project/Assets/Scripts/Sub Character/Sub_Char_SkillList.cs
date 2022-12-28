using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_SkillList : MonoBehaviour
{
    public Dictionary<string, Sub_Char_Skill> Sub_Char_SkilList = new Dictionary<string, Sub_Char_Skill>();

    private void Start()
    {
        create();
    }


    public void create()
    {

        string name;

        name = "Kunai"; //도적 스킬
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(0, name, 20, 0, 0, 5, 1)); //Sub1 Attacker //도적스킬

        name = "Lightning";
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(1, name, 10, 0, 0, 3, 1)); //Sub1 Attacker //매직캐스터 스킬

        name = "Shield"; // Preist Shield Skill
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(2, name, 20, 0, 0, 10, 1));
        //쉴드 미구현

        name = "MegaArrow";
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(3, name, 20, 0, 0, 3, 1));
        //화살 미구현

        name = "AcidCloud"; //방어력 깎기 or "ToxicCloud" 지속 독 데미지
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(4, name, 10, 0, 0, 10, 1));
        //방깎 미구현

        name = "BlizzardStorm"; // 범위형 공격 or 전체공격
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(4, name, 8, 0, 0, 10, 1));
        
    }

}
