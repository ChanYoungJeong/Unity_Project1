using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiateToTarget : MonoBehaviour
{
    public bool isSkill;
    [Header("Ÿ���� ������ �� �ֱ�/�ƴҽ� ��ĭ����")]
    [SerializeField]
    Transform TargetObject;
    bool hasSelectedTarget = false;

    Vector3 TargetPosition;
    [Header("Ÿ���� �������� x,y �� ������")]
    [SerializeField]
    float x;
    [SerializeField]
    float y;

    GameObject prefabObject;
    private Stat stat;

    public AudioClip[] audioClip;
    AudioSource audioSource;

    private float angle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        stat = GetComponentInParent<Stat>();

        if (TargetObject)
        setTarget();
    }

    // Update is called once per frame
    // �÷��̾� ���������� Update�� �ٲ����
    // �����Ƽ� �ϴ� Anmation�� �����س���
    void Update()
    {
        //if (!Battle_Situation_Trigger.monster || !BossScript.boss) return;

        if (!hasSelectedTarget)
        {
            TargetObject = TargetTrans();
            TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
        }
        else
        {
            TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
        }
    }

    void setTarget()
    {
        TargetPosition = new Vector3(TargetObject.position.x + x, TargetObject.position.y + y, 0);
        hasSelectedTarget = true;
    }

    void createPrefabToTarget(GameObject prefab)
    {
        prefabObject = Instantiate(prefab, TargetPosition , Quaternion.identity);
        //���߿� ��ġ �ٲ���ҵ�

        //AudioSource.PlayClipAtPoint(audioClip[Random.Range(0, audioClip.Length - 1)], transform.position);

        SoundEffect();

        if (Mathf.Abs(TargetObject.localScale.x) < Mathf.Abs(prefabObject.transform.localScale.x))
        {
            prefabObject.transform.localScale = new Vector3(-TargetObject.localScale.x, TargetObject.localScale.y, TargetObject.localScale.z);   
        }
        
        setHeal();
        setDamage();


        Destroy(prefabObject, 5f);
    }

    void SoundEffect()
    {
        audioSource.clip = audioClip[Random.Range(0, audioClip.Length - 1)];
        audioSource.Play();
    }

    //���� �������� �� �ϱ�
    void setHeal()
    {
        if(prefabObject.GetComponent<Heal>())
            prefabObject.GetComponent<Heal>().healAmount = stat.atkDamage;
    }

    //���Ŀ� Heal���� �ٸ� ������ ��ũ��Ʈ ���� ����Ұ�
    void setDamage()
    {
        float dmg;
        if (isSkill)
            dmg = stat.skillDamage;
        else
            dmg = stat.atkDamage;
        if (prefabObject.GetComponent<PrefabOnTrigger>())
            prefabObject.GetComponent<PrefabOnTrigger>().damage = dmg;
    }

    public Transform TargetTrans()
    {
        Transform transform = this.transform;
        if (Battle_Situation_Trigger.monster)
        {
            transform = Battle_Situation_Trigger.monster.transform;
        }
        else if (BossScript.boss)
        {
            transform = BossScript.boss.transform;
        }

        return transform;
    }
}
