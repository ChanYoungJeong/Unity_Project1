using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSummon : MonoBehaviour
{
    //index�� �����ҰŸ� ���� if���� ���� �͸� ���ϴ�
    //�� �������� �������� �����Ǿ�� �ϴµ� index�� ����
    //���߿� ���ο��� ���������� �Ѿ�ö�, �ٸ� ������ ���������� �Ѿ���� ��Ұž�
    public int[] AsderCount; //ī��Ʈ�� �� ���������� ������ AsderCall�� ���� �ο��ϸ����
    //����
    //���Ŀ� �迭�� �ƴ� Dictionary�� ���� �ٸ� �ڷᱸ���� �ƿ� �Ⱦ���������
    //����� �������� ������� �迭
    public GameObject[] HeroList;
    //����� �̹����� ������� ����Ʈ
    public Sprite[] HeroImageList;
    private void Awake()
    {
        //���� �ʿ����
        /*
        for(int t=0; t<AsderCount.Length; t++)
        {
            AsderCount[t] = 0;
        }
        */
    }
}
