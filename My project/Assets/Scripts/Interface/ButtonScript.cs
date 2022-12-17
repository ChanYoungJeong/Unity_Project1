using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    PlayerScript playerScript;

    public GameObject Player_Object;
    //public Text buttonText;
    //public Text atkbutton;


    // Start is called before the first frame update
    public int hp_scoreButton;
    public int atk_scoreButton;
    int up_hpgold;
    int up_hpgold1;
    int up_hpgold2;

    int up_atkgold;
    int up_atkgold1;
    int up_atkgold2;

    int up_hp;
    int up_hp1;
    int up_hp2;

    int up_atk;
    int up_atk1;
    int up_atk2;


    float player_hp;
    float player_atk;


    private void Awake()
    {
        //up_hp = 5;
        up_hp1 = 0;
        up_hp2 = 5;
        up_hpgold1 = 0;
        up_hpgold2 = 120;
        up_atkgold1 = 0;
        up_atkgold2 = 120;
        up_atk1 = 0;
        up_atk2 = 3;
        playerScript = Player_Object.GetComponent<PlayerScript>();
        player_hp = playerScript.maxHp;
        player_atk = playerScript.atkDmg;
        up_atkgold = up_atkgold1 + up_atkgold2;
        up_hpgold = up_hpgold1 + up_hpgold2;
       
        
    }
    private void Start()
    {
        CalculateAttack(atk_scoreButton);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void hp_upgradeButton()
    {
            if (Game_System.Gold > up_hpgold)
            {
            Debug.Log("체력 강화 시작");

                //player_hp += up_hp;
                //up_hp += 5;
                up_hp = up_hp1 + up_hp2;
                playerScript.maxHp += up_hp;
                playerScript.nowHp += up_hp;
                up_hp1 = up_hp2;
                up_hp2 = up_hp;

                hp_scoreButton += 1;
                Debug.Log("hp_upcount:" + hp_scoreButton);

            //my_gold -= up_gold;
            //up_gold += 5000;

                Game_System.Gold -= up_hpgold;
                up_hpgold1 = up_hpgold2;
                up_hpgold2 = up_hpgold;

                up_hpgold = up_hpgold1 + up_hpgold2;


                Debug.Log("my_gold : " + Game_System.Gold);
                Debug.Log("player_hp : " + player_hp);
                Debug.Log("next up_gold : " + up_hpgold);
                //buttonText.text = hp_scoreButton.ToString();
        }
    }
    public void atk_upgradeButton()
    {       
        Debug.Log("now_gold : " + Game_System.Gold);
        Debug.Log("up_gold : " + up_atkgold);
            if (Game_System.Gold > up_atkgold)
            {
                up_atk = up_atk1 + up_atk2;
                playerScript.atkDmg += up_atk;
                up_atk1 = up_atk2;
                up_atk2 = up_atk;

                atk_scoreButton += 1;
                Debug.Log("atk_scorebutton:" + atk_scoreButton);


                //up_gold = up_gold1 + up_gold2;
                Game_System.Gold -= up_atkgold;
                up_atkgold1 = up_atkgold2;
                up_atkgold2 = up_atkgold;
                up_atkgold = up_atkgold1 + up_atkgold2;



                Debug.Log("my_gold : " + Game_System.Gold);
                Debug.Log("player_atk : " + player_atk);
                Debug.Log("next up_gold : " + up_atkgold);
                //atkbutton.text = atk_scoreButton.ToString();
        }
    }

    public void CalculateAttack(int N)
    {
        int x, y;
        int x1 = up_atk1;
        int x2 = up_atk2;
        int y1 = up_atkgold1;
        int y2 = up_atkgold2;
        for(int i = 0; i < N; i++)
        {
            x = x1 + x2;
            x2 = x1;
            x1 = x;

            y = y1 + y2;
            y2 = y1;
            y1 = y;
        }
        up_atk1 = x1;
        up_atk2 = x2;
        up_atkgold1 = y1;
        up_atkgold2 = y2;
        playerScript.atkDmg += x1 + x2;
        up_atkgold = y1 + y2;
    }
}