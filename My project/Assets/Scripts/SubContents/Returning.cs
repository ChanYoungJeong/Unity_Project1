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
        //Stat���ٰ� ResetStat�Լ� ������ ����
        //default stat�� ���� ���踦 �˾ƾ���
        //������ ������ ������ ���� ���� ��ȭ ���踦 �𸣱� ������ ���߿� ������ȹ
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
