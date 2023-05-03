using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOnTrigger : MonoBehaviour
{
    public GameObject pointer;
    //사용방법
    /* 기존 투사체에 PrefabOnTrigger대신 이 스크립트를 장착
     * InstatiatePrefab에 현재 스크립트를 장착한(투사체) 이펙트를 발사체로 설정
     * 아래 Impact 폭발 이펙트 연결
     * Impact오브젝트에 PrefabOnTrigger,Collider, RigidBody를 넣는다.(그래야 터질 시 임펙트에 맞춰서 데미지가 들어감)
     * 
     * InstatiateToTarget의 createPrefabToTarget를 애니메이터 이벤트에 설정하고
     * Resource/Prefabs/Skills에 PrefabPointer(빨간점) 을 오브젝트로 설정하면 끝
     */
    public GameObject Impact;
    public float damage;

    //Pointer가 동시에 여러개 생성 시 그 지점에서 폭발하는 오류가 있음
    //추후 수정 예정
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pointer")
        {
            if (Impact != null)
            {
                GameObject impact = Instantiate(Impact, this.transform.position, this.transform.rotation);
                impact.GetComponent<PrefabOnTrigger>().damage = damage;
                Game_System.setParentHolder(impact.transform);
                Destroy(this.gameObject);
                Destroy(impact, 1);   //파이클 시스템의 Stop Action 설정을 Destroy로 변경하면 이펙트가 끝날 시 자동으로 파괴됩니다
                Destroy(collision.gameObject); //일부러 넣어 놓은 겁니다. 빨간 점 없엘라고
            }
        }
        
        //Destroy(gameObject);
    }
}

