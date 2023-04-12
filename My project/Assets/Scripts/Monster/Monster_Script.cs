using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public string monsterType;
    public float maxHp;
    public float nowHp;
    public float atkDmg;
    public float atkSpeed;
    public int Golds;
    public int Exp;

    public GameObject MonsterDieAnimation;
    Stat PlayerStat;
    PlayerExpBar playerExp;

    private void Awake()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerStat = Player.GetComponent<Stat>();
        playerExp = Player.GetComponent<PlayerExpBar>();
    }

    private void Update()
    {
        if (nowHp <= 0)
        {
            Monster_Die();
            playerExp.GetExp(Exp);
            Game_System.Gold += Golds;
        }
    }
    public void Monster_Die()
    {
       Instantiate(MonsterDieAnimation, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        //ShowPlayerStat();
    }

    void ShowPlayerStat()
    {
        Debug.Log("EXP: " + PlayerStat.nowExp);
        Debug.Log("Lv: " + PlayerStat.lv);
    }
}
