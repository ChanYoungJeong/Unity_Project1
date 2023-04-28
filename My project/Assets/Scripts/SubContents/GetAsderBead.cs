using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetAsderBead : MonoBehaviour
{
    public AsderCall AsderCount;
    public HeroSummon heroSummon;

    //이게 프리펩으로 소환되는거라 AsderCount를 public으로 끌어서 받아올 수 가 없다
    //BeadType을 비교해서 AsderCall을 올리는 걸로 해라

    //AsderCount에서 BeadCount를 올리는 과정은 if문을 써도 되지만
    //눌러서 소환하는거 if문 쓰면 죽인다

    //Asder소환하는거는 동적으로 작동하게 해라
    //힌트 : Asder갯수 올리는거랑 소환하는거랑 스크립트 분리해라
    //     : Asder갯수 올리는 스크립트에는 오른쪽에 있는 각 에스더의 갯수랑,
    //              존재여부만 관리하는 Manager 한개만 있으면됨
    //     : Asder소환하는 스크립트는 각 에스더에게 부여해서
    //              어떤 스크립트를 소환할 지 동적할당.


    //BeadType으로 어떤 Asder를 올리는 구슬인지 결정
    public string BeadType;

    public void Awake()
    {
        heroSummon = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        //파인드 쓰지 않는 방법 찾기
        setSubcharType(BeadType);
    }

    void setSubcharType(string Type)
    {
        if (Type == "Archer")
            ChangeBeadColor(Color.green);
        else if (Type == "Rogue")
            ChangeBeadColor(Color.blue);
        else if (Type == "Wizzard")
            ChangeBeadColor(Color.red);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player(SubContent)")
        {
            //여기만 다시만들어 내 생각에는 이제 if로 구분하는것도 필요없다.
            //힌트 : 찾을때만 쓸것
           


            //

            Destroy(this.gameObject);
        }

    }
   
    void ChangeBeadColor(Color color)
    {
        Debug.Log(color);
        GetComponent<SpriteRenderer>().color = color;
    }
}
