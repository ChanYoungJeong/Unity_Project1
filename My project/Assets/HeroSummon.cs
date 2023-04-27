using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSummon : MonoBehaviour
{
    //index로 관리할거면 차라리 if문을 쓰는 것만 못하다
    //각 에스더가 동적으로 관리되어야 하는데 index로 쓰면
    //나중에 메인에서 서브컨텐츠 넘어올때, 다른 조합의 보조영웅이 넘어오면 어떡할거야
    public int[] AsderCount; //카운트를 왜 통합적으로 관리함 AsderCall에 각자 부여하면되지
    //찬영
    //추후에 배열이 아닌 Dictionary와 같은 다른 자료구조나 아예 안쓸수도있음
    //히어로 프리펩을 담기위한 배열
    public GameObject[] HeroList;
    //히어로 이미지를 담기위한 리스트
    public Sprite[] HeroImageList;
    private void Awake()
    {
        //전혀 필요없음
        /*
        for(int t=0; t<AsderCount.Length; t++)
        {
            AsderCount[t] = 0;
        }
        */
    }
}
