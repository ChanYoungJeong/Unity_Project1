using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Char_SkillList : MonoBehaviour
{
    SubChar_Combat_manager subChar_Combat_Manager;
    public Dictionary<string, Sub_Char_Skill> Sub_Char_SkilList = new Dictionary<string, Sub_Char_Skill>();

    
    private void Start()
    {
        subChar_Combat_Manager = gameObject.GetComponentInParent<SubChar_Combat_manager>();
        create();
    }

    public void create()
    {
        string name;

        float SubAttackDamege = subChar_Combat_Manager.attack * 1.5f;
        name = "Sharpness";
        Sub_Char_SkilList.Add(name, new Sub_Char_Skill(0, name, SubAttackDamege, 0.25f, 27.0f, 1));

    }
  
}
