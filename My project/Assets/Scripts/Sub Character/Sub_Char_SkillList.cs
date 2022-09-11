using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_SkillList : MonoBehaviour
{
    Sub_CharStats sub_charstats;
    public Dictionary<string, Sub_Char_Skill> Sub_Char_SkilList = new Dictionary<string, Sub_Char_Skill>();

    /*
    private void Start()
    {
        sub_charstats = gameObject.GetComponentInParent<Sub_CharStats>();
        create();
    }

    public void create()
    {
        string name;

        float SubAttackDamege = sub_charstats.attack * 1.5;
        name = "Sharpness";
        Sub_Char_skilList.Add(name, new Skills(0, name, SubAttackDamege, 0.25f, 27.0f, 1));

    }
    */
}
