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
    PlayerScript playerScript;

    private void Awake()
    {
        if (GameObject.Find("Player") != null)
        {
            playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        }
    }

    private void Update()
    {
        if (nowHp <= 0)
        {
            Monster_Die();
            playerScript.GetExp();
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
        Debug.Log("EXP: " + playerScript.playerNowExp);
        Debug.Log("Lv: " + playerScript.lv);
    }
}
