using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monster : MonoBehaviour
{
    public string Monster_Name;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public int atkSpeed;
    public player_script player;
    Image nowHpbar;

    public GameObject prfHpbar;
    public GameObject canvas;

    RectTransform hpBar;

    public float height = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prfHpbar, canvas.transform).GetComponent<RectTransform>();       // instantiate(���ӿ�����Ʈ, �θ���trnsform)���� ������Ʈ�� �����ϴ� �Լ�
        if (name.Equals("Monster1"))
        {
            SetMonsterStatus("Monster1", 100, 10, 1);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x-1, transform.position.y + height, 0)); //Camera.main.WorldToScreenPoint(���� ��ǥ ��) ���� ��ǥ�� ��ũ�� ��ǥ ��, UI��ǥ�� �ٲ��ִ� �Լ�
        hpBar.position = _hpBarPos; // ������ ü�¹ٸ� �̵�
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
        Debug.Log("�浹��1");
        if (collision.CompareTag("Player"))              //�� �� ���� ������Ʈ�� �ٲ����
        {
            player.attacked = true;

            Debug.Log("�浹��2");
            if (player.attacked)
            {
                Debug.Log("�浹��3");
                nowHp -= player.atkDmg;
                Debug.Log(nowHp);
                player.attacked = false;

                if (nowHp <= 0)
                {
                    Destroy(gameObject);
                    Destroy(hpBar.gameObject);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�浹��1-1");
    }

}
