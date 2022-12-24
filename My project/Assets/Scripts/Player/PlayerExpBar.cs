using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    public Slider expSlider;
    [SerializeField]
    PlayerScript playerStat;
    float maxExp;
    float curExp;

    // Start is called before the first frame update
    void Awake()
    {
        playerStat = this.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        maxExp = playerStat.playerMaxExp;
        curExp = playerStat.playerNowExp;
        expSlider.value = Mathf.Lerp(expSlider.value, curExp / maxExp, Time.deltaTime * 5f);
    }
}
