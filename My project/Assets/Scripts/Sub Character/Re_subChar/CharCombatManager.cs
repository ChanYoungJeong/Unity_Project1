using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCombatManager : MonoBehaviour
{
    public bool isBasicAttack;
    public bool isSkillAttack;
    public float timer;
    Stat CharStat;
    // Start is called before the first frame update
    void Awake()
    {
        CharStat = GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }
}
