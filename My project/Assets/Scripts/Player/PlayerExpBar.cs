using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    public Slider expSlider;
    [SerializeField]
    Stat playerStat;
    float maxExp;
    float curExp;

    // Start is called before the first frame update
    void Awake()
    {
        playerStat = GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        maxExp = playerStat.player_maxExp;
        curExp = playerStat.player_nowExp;
        expSlider.value = Mathf.Lerp(expSlider.value, curExp / maxExp, Time.deltaTime * 5f);
    }
}
