using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    [Header("monster stats")]
    public string Monster_Name;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

    [Header("commons")]
    public player_script player;
    Image nowHpbar;

    public GameObject prfHpbar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
        hpBar = Instantiate(prfHpbar, canvas.transform).GetComponent<RectTransform>();       // instantiate(게임오브젝트, 부모의trnsform)게임 오브젝트를 생성하는 함수
        if (name.Equals("Monster1(Clone)"))
        {
            SetMonsterStatus("Monster1(Clone)", 100, 10, 1);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        
    }
    private
    // Update is called once per frame
    void Update()
    {
        
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+height, 0)); //Camera.main.WorldToScreenPoint(월드 좌표 값) 월드 좌표를 스크린 좌표 즉, UI좌표로 바꿔주는 함수
        hpBar.position = _hpBarPos; // 생성된 체력바를 이동
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
    
    private void SetMonsterStatus(string _Monster_Name, int _maxHp, int _atkDmg, int _atkSpeed)
    {
        Monster_Name = _Monster_Name;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision1");
        if (collision.CompareTag("Player"))              //추후 무기 오브젝트로 바꿔야함(Need to change to weapon object in the future)
        {
            Debug.Log("collision2");

            player.attacked = true;              // 플레이어 공격 활성화(Enable Player Attacks)

            

            if (player.attacked)
            {
                Debug.Log("collision3");
                nowHp -= player.atkDmg;
                Debug.Log(player.atkDmg);
                Debug.Log(nowHp);
                player.attacked = false;                    // 플레이어 공격 비활성화 (Disable Player Attacks)

                if (nowHp <= 0)                         // 몬스터 hp가 0이 되면 오브젝트 파괴(Destroy the object when the monster hp becomes zero)
                {
                    Destroy(gameObject);
                    Destroy(hpBar.gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision1-1");
    }

}
