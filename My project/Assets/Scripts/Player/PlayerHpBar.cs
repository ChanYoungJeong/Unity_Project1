using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    public Slider hpSlider;
    Stat playerStat;
    float maxHp;
    float curHp;

    // Start is called before the first frame update
    void Awake()
    {
        playerStat = GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        maxHp = playerStat.player_maxHp;
        curHp = playerStat.player_noxHp;
        hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, Time.deltaTime * 5f);
    }
}
