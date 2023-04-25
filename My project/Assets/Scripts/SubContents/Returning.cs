using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Returning : MonoBehaviour
{
    public CreateMonster_Manager CMM;
    public GameObject[] Holder;
    public Stat Player;


    public float timer;

    public void ReturnButton()
    {
        Time.timeScale = 0;
        ResetData();
        DestroyObjects();

        if (CMM.group != null)
            Destroy(CMM.group);
        
        
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        while(timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
            yield return null;
        }

        if (timer < 0)
        {
            Time.timeScale = 1;
            timer = 1.0f;
        }
    }

    void ResetData()
    {
        //GameSystems
        Game_System.Stage = 0;
        Game_System.Gold = 0;

        //Player
        //Stat에다가 ResetStat함수 생성할 것임
        //default stat에 대한 관계를 알아야함
        //지금은 아이템 장착에 따른 스텟 변화 관계를 모르기 때문에 나중에 수정계획
        Player.nowExp = 0;
        Player.maxExp = 15;
        Player.lv = 1;
    }

    void DestroyObjects()
    {
        for(int i = 0; i < Holder.Length; i++)
        {
            foreach (Transform child in Holder[i].transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
