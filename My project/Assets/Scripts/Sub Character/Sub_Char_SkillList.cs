using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_SkillList : MonoBehaviour
{
    SubChar_Combat_manager subChar_Combat_Manager;
    public Dictionary<string, Sub_Char_Skill> Sub_Char_SkilList = new Dictionary<string, Sub_Char_Skill>();

    private void Awake()
    {
        create();
    }

    private void Start()
    {
        subChar_Combat_Manager = gameObject.GetComponentInParent<SubChar_Combat_manager>();
    }

    public void create()
    {
        string name;

        float subAttackDamege = subChar_Combat_Manager.attackDmg * 1.5f;
        name = "dagger"; //도적 스킬
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(0, name, subAttackDamege, 0, 0, 15, 1)); //Sub1 Attacker //도적스킬
        
    }
  
}
