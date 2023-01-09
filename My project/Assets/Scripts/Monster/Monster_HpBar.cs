using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_HpBar : MonoBehaviour
{
    public Slider hpSlider;
    public Canvas hpCanvas;
    [SerializeField]
    Monster_Script monsterStat;
    float maxHp;
    float curHp;

    // Start is called before the first frame update
    void Awake()
    {
        monsterStat = this.GetComponent<Monster_Script>();

    }

    // Update is called once per frame
    void Update()
    {
        maxHp = monsterStat.maxHp;
        curHp = monsterStat.nowHp;
        hpCanvas.transform.position = this.transform.position;
        hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, Time.deltaTime * 5f);
    }
}
