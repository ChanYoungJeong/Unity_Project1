using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HpBar : MonoBehaviour
{
    public Slider hpSlider;
    public Canvas hpCanvas;
    [SerializeField]
    BossMonster BossStat;
    float maxHp;
    float curHp;

    void Awake()
    {
        BossStat = this.GetComponent<BossMonster>();
    }
    void Update()
    {
        maxHp = BossStat.maxHp;
        curHp = BossStat.nowHp;
        hpCanvas.transform.position = this.transform.position;
        hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, Time.deltaTime * 5f);
    }
}
