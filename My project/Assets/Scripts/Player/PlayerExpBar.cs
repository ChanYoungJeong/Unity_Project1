using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    public GameObject PlayerText;
    public Transform TextPrinter;
    public Slider expSlider;
    Stat stat;
    float maxExp;
    float curExp;

    // Start is called before the first frame update
    void Awake()
    {
        stat = GetComponent<Stat>();
    }

    private void Start()
    {
        expSlider.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        maxExp = stat.maxExp;
        curExp = stat.nowExp;
        expSlider.value = Mathf.Lerp(expSlider.value, curExp / maxExp, Time.deltaTime * 5f);

        if(curExp >= maxExp)
        {
            float remainder = curExp - maxExp; //획득 경험치가 max보다 초과하면 나머지만큼 다음 레벨 exp에 더해줌
            LvUp();
            stat.nowExp += remainder;
        }
    }


    public void LvUp()
    {
        stat.lv++;
        DisplayText(stat.lv + " Level UP", Color.yellow);
        SetStat();
        SetMaxExp();
    }

    void DisplayText(string text, Color color)
    {
        GameObject hudText = Instantiate(PlayerText);
        hudText.transform.position = TextPrinter.position;
        hudText.GetComponent<PlayerText>()._Text = text;
        hudText.GetComponent<PlayerText>().textColor = color;
    }

    //Monster Combat에서 작동할것임
    public void GetExp(float monsterExp)
    {
        stat.nowExp += monsterExp;
    }


    public void SetMaxExp()
    {
        stat.maxExp = stat.maxExp + stat.lv * stat.lv * 5;
    }

    void SetStat()
    {
        float LvUp_Atk = 1f;
        float LvUp_Hp = 2f;
        float LvUp_CriticalRate = 0.1f;

        stat.nowExp = 0;
        stat.atkDamage += (LvUp_Atk * stat.lv);
        stat.maxHp += (LvUp_Hp * stat.lv);
        stat.nowHp += (LvUp_Hp * stat.lv);
        stat.criticalRate += (LvUp_CriticalRate * stat.lv);
    }
}
