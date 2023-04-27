using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class AsderCall : MonoBehaviour
{
    //GetAsderBead Getasderbead;
    /*
    public Transform PlayerTrans;
    public GameObject subHeroPrefab;
    public HeroSummon BeadCount;
    public int subHeroNum;
    */
    //찬영
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private GameObject subCharPrefab;
    public string Type;
    HeroSummon heroSummon;
    public int beadCount;
    Button thisButton;

    public float y;
    public float DestroyTime;


    private void Awake()
    {
        //BeadCount = GameObject.Find("GameManager").GetComponent<HeroSummon>();

        //Find굳이 안써도됨
        heroSummon = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        Player = GameObject.FindWithTag("Player").transform;
        thisButton = GetComponent<Button>();

        //임시용 for문
        //heroSummon의 리스트에서 현재 버튼에 할당된 Type명에 따라 소환할 prefab과 이미지를 불러옴
        for (int i = 0; i < heroSummon.HeroList.Length; i++)
        {
            if (Type == heroSummon.HeroList[i].name)
                subCharPrefab = heroSummon.HeroList[i];
        }

        for (int i = 0; i < heroSummon.HeroImageList.Length; i++)
        {
            if (Type == heroSummon.HeroImageList[i].name)
                GetComponent<Image>().sprite = heroSummon.HeroImageList[i];
        }
    }

    private void Update()
    {
        //이 AsderCall의 beadCount에 따라 버튼 누르는 여부 설정
        if (beadCount > 0)
            thisButton.interactable = true;
        else
            thisButton.interactable = false;
    }

    //int N 왜있는거임?
    public void CallAsder(int N)
    {
        Debug.Log("here");
        GameObject subHeroClone = Instantiate(subCharPrefab, Player.position + Vector3.right * 1.0f, Quaternion.identity);
        subHeroClone.transform.rotation = Quaternion.Euler(0, y, 0);

        Destroy(subHeroClone, DestroyTime);
        beadCount--;
    }
}