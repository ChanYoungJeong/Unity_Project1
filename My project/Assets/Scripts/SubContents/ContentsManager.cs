using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentsManager : MonoBehaviour
{
    public bool startContent;
    public Stat PlayerStat;
    [Header("Timer Setting")]
    public Text timeText;
    public float time;

 
    private void Awake()
    {
        timeText.text = Mathf.Ceil(time).ToString();
        startContent = false;
    }

    public void StartContent()
    {
        startContent = true;
    }

    public void Update()
    {
        if (startContent && time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = string.Format("{0:N2}", time);
        }
        if(time <= 0 || PlayerStat.nowHp <= 0)
        {
            startContent = false;
            Time.timeScale = 0f;
        }
    }
}
