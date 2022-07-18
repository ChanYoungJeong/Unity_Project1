using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [Header("monster stats")]
    public string monsterName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;

    [Header("commons")]
    public PlayerScript player;
    Image nowHpbar;

    public GameObject prfHpbar;
    public GameObject canvas;
    public RectTransform hpBar;


    public float height = 1f;


    void Start()
    {
        maxHp = 100;
        nowHp = 100;
        
        hpBar = Instantiate(prfHpbar, canvas.transform).GetComponent<RectTransform>();                                          // instantiate(게임오브젝트, 부모의trnsform)게임 오브젝트를 생성하는 함수
        if (name.Equals("Monster1(Clone)"))
        {
            SetMonsterStatus("Monster1(Clone)", 100, 10, 1);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        
    }
    private
    void Update()
    {
        
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+height, 0));  //Camera.main.WorldToScreenPoint(월드 좌표 값) 월드 좌표를 스크린 좌표 즉, UI좌표로 바꿔주는 함수
        hpBar.position = _hpBarPos;                                                                                             // 생성된 체력바를 이동
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
    
    private void SetMonsterStatus(string _Monster_Name, int _maxHp, int _atkDmg, int _atkSpeed)
    {
        monsterName = _Monster_Name;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
    }


}
