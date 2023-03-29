using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueStat : MonoBehaviour
{
    public float maxHealth;       
    public float nowHealth;
    public float atkDamage;
    public float criticalRate;
    public float atkSpeed;
    public int lv;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        maxHealth = 200f;
        nowHealth = maxHealth;
        atkDamage = 15f;
        criticalRate = 0f;
        atkSpeed = 2.5f;
        lv = 1;
    }
}
