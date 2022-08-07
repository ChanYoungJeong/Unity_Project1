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

        my_gold = Game_System.Gold;
    }

    // Update is called once per frame
    private void Update()
    {

        buttonText.text = hp_scoreButton.ToString();
        atkbutton.text = atk_scoreButton.ToString();
    }

    public void hp_upgradeButton()
    {
        if (hp_scoreButton == 0) //버튼 처음 눌렀을 때만 실행
        {
            my_gold = Game_System.Gold;
        }
        Debug.Log("현제 골드 : " + my_gold);
        Debug.Log("강화 금액 : " + up_gold);

        click = true;
        if (click)
        {
            if (my_gold > up_gold)
            {
                //player_hp = playerScript.maxHp;
                player_hp += up_hp;
                up_hp += 5;

                hp_scoreButton += 1;
                Debug.Log("업그레이드 횟수:" + hp_scoreButton);

                my_gold -= up_gold;
                up_gold += 5000;

                Debug.Log("남은 골드 : " + my_gold);
                Debug.Log("현제 체력 : " + player_hp);
                Debug.Log("다음 강화 금액 : " + up_gold);
                click = false;
            }
        }

    }
    public void atk_upgradeButton()
    {
        if (atk_scoreButton == 0) //버튼 처음 눌렀을 때만 실행
        {
            my_gold = Game_System.Gold;
        }
        Debug.Log("현제 골드 : " + my_gold);
        Debug.Log("강화 금액 : " + up_gold);

        click = true;
        if (click)
        {
            if (my_gold > up_gold)
            {
                //player_hp = playerScript.maxHp;
                player_atk += up_atk;
                up_atk += 10;

                atk_scoreButton += 1;
                Debug.Log("업그레이드 횟수:" + atk_scoreButton);

                my_gold -= up_gold;
                up_gold += 5000;

                Debug.Log("남은 골드 : " + my_gold);
                Debug.Log("공격력 : " + player_atk);
                Debug.Log("다음 강화 금액 : " + up_gold);
                click = false;
            }
        }

    }
}