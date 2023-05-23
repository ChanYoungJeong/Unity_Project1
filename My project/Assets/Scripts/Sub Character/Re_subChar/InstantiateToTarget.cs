using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InstantiateToTarget : MonoBehaviour
{
    public bool isSkill;
    [Header("타겟이 정적일 시 넣기/아닐시 빈칸으로")]
    [SerializeField]
    Transform TargetObject;
    bool hasSelectedTarget = false;

    Vector3 TargetPosition;
    [Header("타겟을 기준으로 x,y 축 조정값")]
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
    // 플레이어 서브컨텐츠 Update문 바꿔야함
    // 귀찮아서 일단 Anmation에 세팅해놨음
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
        //나중에 위치 바꿔야할듯

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

    //힐이 있을경우는 힐 하기
    void setHeal()
    {
        if(prefabObject.GetComponent<Heal>())
            prefabObject.GetComponent<Heal>().healAmount = stat.atkDamage;
    }

    //추후에 Heal말고 다른 데미지 스크립트 사용시 사용할것
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
