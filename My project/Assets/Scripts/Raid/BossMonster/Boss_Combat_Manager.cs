using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Combat_Manager : MonoBehaviour
{
    BossMonster_Script BossHP;

    public Transform DamagePrinter;
    public GameObject DamageText;
    public GameObject CriticalDamageText;
    public bool on = true;
   
    void Start()
    {
        
    }
    void Update()
    {

    }

    // startBtn 클릭시 게임 실행
    void StartGame()
    {
        if (on == true)
        {
            
        }

        else if (on == false)
        {

        }
    }

    public void ApplyDamage(float damage, Color color, float ciritcalRate, float criticalDamage)
    {

        if (Random.Range(0, 100) < ciritcalRate)
        {
            BossHP.nowHp -= Mathf.RoundToInt(damage * criticalDamage);
            GameObject hudText = Instantiate(CriticalDamageText);
            hudText.transform.position = DamagePrinter.position;
            hudText.GetComponent<DamageText>().damage = Mathf.RoundToInt(damage * criticalDamage);
            hudText.GetComponent<DamageText>().damageColor = color;
        }
        else
        {
            BossHP.nowHp -= damage;
            GameObject hudText = Instantiate(DamageText);
            hudText.transform.position = DamagePrinter.position;
            hudText.GetComponent<DamageText>().damage = damage;
            hudText.GetComponent<DamageText>().damageColor = color;
        }
    }

}