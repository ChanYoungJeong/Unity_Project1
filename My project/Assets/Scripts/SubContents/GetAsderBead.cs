using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetAsderBead : MonoBehaviour
{
    public HeroSummon heroSummon;
    ButtonShadow BS;
    //�̰� ���������� ��ȯ�Ǵ°Ŷ� AsderCount�� public���� ��� �޾ƿ� �� �� ����
    //BeadType�� ���ؼ� AsderCall�� �ø��� �ɷ� �ض�

    //AsderCount���� BeadCount�� �ø��� ������ if���� �ᵵ ������
    //������ ��ȯ�ϴ°� if�� ���� ���δ�

    //Asder��ȯ�ϴ°Ŵ� �������� �۵��ϰ� �ض�
    //��Ʈ : Asder���� �ø��°Ŷ� ��ȯ�ϴ°Ŷ� ��ũ��Ʈ �и��ض�
    //     : Asder���� �ø��� ��ũ��Ʈ���� �����ʿ� �ִ� �� �������� ������,
    //              ���翩�θ� �����ϴ� Manager �Ѱ��� �������
    //     : Asder��ȯ�ϴ� ��ũ��Ʈ�� �� ���������� �ο��ؼ�
    //              � ��ũ��Ʈ�� ��ȯ�� �� �����Ҵ�.


    //BeadType���� � Asder�� �ø��� �������� ����
    public string BeadType;

    public void Awake()
    {
        //heroSummon = GameObject.Find("GameManager").GetComponent<HeroSummon>();
        //���ε� ���� �ʴ� ��� ã��
        BS = GameObject.FindWithTag("GameManager").GetComponent<ButtonShadow>();
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
            //BeadCount �� ���� AsderCall�� ���� �����Ǵµ� �� HeroSummon��?
            //HeroSummon�� �̿��ҰŸ� �ּ��� AsderCall�� BeadCount�� ������Ѿ���
            for(int i = 0; i < BS.SubButtons.Length; i++)
            {
                AsderCall AC = BS.SubButtons[i].GetComponent<AsderCall>();
                if (AC.Type == BeadType)
                {
                    AC.beadCount++;
                    break;
                }
            }
            Destroy(this.gameObject);
        }

    }

    void ChangeBeadColor(Color color)
    {
        Debug.Log(color);
        GetComponent<SpriteRenderer>().color = color;
    }
}
