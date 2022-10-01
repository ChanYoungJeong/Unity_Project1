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

        /* name = "Shield"; // Priest Skill
         * Sub_Char_SkillList.Add(namem new Sub_Char_Skill*/
    }
  
}
