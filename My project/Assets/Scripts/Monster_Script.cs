using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Script : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("monster stats")]
    public string monsterName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;
    public int Golds;


    [Header("commons")]
    public PlayerScript player;
    Image nowHpbar;
    public GameObject prfHpbar;
    public GameObject canvas;
    public RectTransform hpBar;


    public float height = 1f;

    //Outside Scripts

    void Start()
    {
        maxHp = 100;
        nowHp = 100;

        hpBar = Instantiate(prfHpbar, canvas.transform).GetComponent<RectTransform>();
        if (name.Equals("Monster1(Clone)"))
        {
            SetMonsterStatus("Monster1(Clone)", 100, 10, 1,100);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();

    }
    private
    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;


        if (nowHp <= 0)
        {
            Monster_Die();
        }
        
    }

    private void SetMonsterStatus(string _Monster_Name, int _maxHp, int _atkDmg, int _atkSpeed, int _Golds)
    {
        monsterName = _Monster_Name;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
        Golds = _Golds;
    }

    void Monster_Die()
    { 
        Destroy(this.gameObject);
        Game_System.Gold += Golds;
    }

}
