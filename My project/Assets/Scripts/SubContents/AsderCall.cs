using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class AsderCall : MonoBehaviour
{
    //GetAsderBead Getasderbead;
    public Transform PlayerTrans;
    public GameObject subHeroPrefab;
    public HeroSummon BeadCount;
    public int subHeroNum;

    public float y;
    public float DestroyTime;

    private void Awake()
    {
        BeadCount = GameObject.Find("GameManager").GetComponent<HeroSummon>();
    }
    public void CallAsder(int N)
    {

        GameObject subHeroClone = Instantiate(subHeroPrefab, PlayerTrans.position + Vector3.right * 1.0f, Quaternion.identity);
        subHeroClone.transform.rotation = Quaternion.Euler(0, y, 0);

        Destroy(subHeroClone, DestroyTime);
        BeadCount.AsderCount[subHeroNum]--;

    }
}