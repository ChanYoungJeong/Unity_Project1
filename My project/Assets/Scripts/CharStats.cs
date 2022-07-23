using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public float maxHealth = 100;   // max HP
    public float curHealth { get; private set; } 
    public float maxMP = 50; //max MP
    public float curMP { get; private set; }
    float attack = 10; // damage
    public Stat damage;


    private void Awake()
    {
        curHealth = maxHealth;
        curMP = maxMP;
    }

    public void TakeDamage(int damage) // HP - monster damage
    {
        curHealth -= damage;
    }
}