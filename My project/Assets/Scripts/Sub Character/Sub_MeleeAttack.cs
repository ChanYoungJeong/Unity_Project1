using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_MeleeAttack : MonoBehaviour
{
    public Animator anim;
    SubChar_Combat_manager subStats;

    public GameObject[] assassinWeapon;

    private void Start()
    {
        subStats = GetComponent<SubChar_Combat_manager>();
    }


}
