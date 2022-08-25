using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    PlayerScript playerScript;

    public GameObject Player_Object;
    public Text buttonText;
    public Text atkbutton;


    // Start is called before the first frame update
    int hp_scoreButton;
    int atk_scoreButton;
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

    bool click = false;

    int my_gold;
    float player_hp;
    float player_atk;


    private void Awake()
    {
        hp_scoreButton = 0;
        atk_scoreButton = 0;
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


        //my_gold = Game_System.Gold;
    }

    // Update is called once per frame
    private void Update()
    {

        buttonText.text = hp_scoreButton.ToString();
        atkbutton.text = atk_scoreButton.ToString();
    }

    public void hp_upgradeButton()
    {
        if (atk_scoreButton == 0)
        {
            my_gold = Game_System.Gold;
        }
        Debug.Log("now_gold : " + my_gold);
        Debug.Log("up_gold : " + up_hpgold);
        click = true;
        if (click)
        {
            if (my_gold > up_hpgold)
            {
                //player_hp += up_hp;
                //up_hp += 5;
                up_hp = up_hp1 + up_hp2;
                player_hp += up_hp;
                up_hp1 = up_hp2;
                up_hp2 = up_hp;

                hp_scoreButton += 1;
                Debug.Log("hp_upcount:" + hp_scoreButton);

                //my_gold -= up_gold;
                //up_gold += 5000;
                
                my_gold -= up_hpgold;
                up_hpgold1 = up_hpgold2;
                up_hpgold2 = up_hpgold;

                up_hpgold = up_hpgold1 + up_hpgold2;


                Debug.Log("my_gold : " + my_gold);
                Debug.Log("player_hp : " + player_hp);
                Debug.Log("next up_gold : " + up_hpgold);
                click = false;
            }
        }

    }
    public void atk_upgradeButton()
    {
        if (hp_scoreButton == 0)
        {
            my_gold = Game_System.Gold;
        }
        Debug.Log("now_gold : " + my_gold);
        Debug.Log("up_gold : " + up_atkgold);
        click = true;
        if (click)
        {
            if (my_gold > up_atkgold)
            {

                up_atk = up_atk1 + up_atk2;
                player_atk += up_atk;
                up_atk1 = up_atk2;
                up_atk2 = up_atk;

                atk_scoreButton += 1;
                Debug.Log("atk_scorebutton:" + atk_scoreButton);

                
                //up_gold = up_gold1 + up_gold2;
                my_gold -= up_atkgold;
                up_atkgold1 = up_atkgold2;
                up_atkgold2 = up_atkgold;
                up_atkgold = up_atkgold1 + up_atkgold2;



                Debug.Log("my_gold : " + my_gold);
                Debug.Log("player_atk : " + player_atk);
                Debug.Log("next up_gold : " + up_atkgold);
                click = false;
            }
        }

    }
}