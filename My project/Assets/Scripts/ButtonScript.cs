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
    int up_gold;
    int up_hp;
    int up_atk;

    bool click = false;

    int my_gold;
    int player_hp;
    int player_atk;


    private void Awake()
    {
        hp_scoreButton = 0;
        atk_scoreButton = 0;
        up_hp = 5;
        up_gold = 20000;
        up_atk = 10;
        playerScript = Player_Object.GetComponent<PlayerScript>();
        player_hp = playerScript.maxHp;
        player_atk = playerScript.atkDmg;

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
        Debug.Log("up_gold : " + up_gold);
        click = true;
        if (click)
        {
            if (my_gold > up_gold)
            {
                player_hp += up_hp;
                up_hp += 5;

                hp_scoreButton += 1;
                Debug.Log("hp_upcount:" + hp_scoreButton);

                my_gold -= up_gold;
                up_gold += 5000;

                Debug.Log("my_gold : " + my_gold);
                Debug.Log("player_hp : " + player_hp);
                Debug.Log("next up_gold : " + up_gold);
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
        Debug.Log("up_gold : " + up_gold);
        click = true;
        if (click)
        {
            if (my_gold > up_gold)
            {
              
                player_atk += up_atk;
                up_atk += 10;

                atk_scoreButton += 1;
                Debug.Log("atk_scorebutton:" + atk_scoreButton);

                my_gold -= up_gold;
                up_gold += 5000;

                Debug.Log("my_gold : " + my_gold);
                Debug.Log("player_atk : " + player_atk);
                Debug.Log("next up_gold : " + up_gold);
                click = false;
            }
        }

    }
}