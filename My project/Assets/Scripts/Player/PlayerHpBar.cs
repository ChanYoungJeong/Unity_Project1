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

    private void Start()
    {
        hpSlider.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        maxHp = playerStat.maxHp;
        curHp = playerStat.nowHp;
        hpSlider.value = Mathf.Lerp(hpSlider.value, curHp / maxHp, Time.deltaTime * 5f);
    }
}
