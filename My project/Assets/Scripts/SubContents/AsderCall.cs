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
    //����
    [SerializeField]
    private Transform Player;
    [SerializeField]
    private GameObject subCharPrefab;

    public string Type;
    public int beadCount;
    public HeroSummon heroSummon;
    public float y;
    public float DestroyTime;

    Button thisButton;


    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        thisButton = GetComponent<Button>();

        //�ӽÿ� for��
        //heroSummon�� ����Ʈ���� ���� ��ư�� �Ҵ�� Type�� ���� ��ȯ�� prefab�� �̹����� �ҷ���
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
        //�� AsderCall�� beadCount�� ���� ��ư ������ ���� ����
        
        if (beadCount > 0)
            thisButton.interactable = true;
        else
            thisButton.interactable = false;

        SetAsderCount(this.name);
    }

    
    public void CallAsder()
    {
        Debug.Log("here");
        GameObject subHeroClone = Instantiate(subCharPrefab, Player.position + Vector3.right * 1.0f, Quaternion.identity);
        subHeroClone.transform.rotation = Quaternion.Euler(0, y, 0);

        Destroy(subHeroClone, DestroyTime);
        beadCount--;
    }

    void SetAsderCount(string name)
    {
        for(int i = 0; i< heroSummon.HeroList.Length; i++)
        {
            if (name == heroSummon.HeroList[i].name && heroSummon.AsderCount[i] != 0)
            {
                beadCount = heroSummon.AsderCount[i];

                Debug.Log(beadCount);
            }
        }
    }
}