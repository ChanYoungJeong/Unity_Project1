using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSlash : MonoBehaviour
{
    public GameObject doubleSlashPrefaps;
    public GameObject GameSytstem;
    GameObject doubleSlash;
    public GameObject Monster;

    float x;
    float y;


    public void SkillAtack()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.25f);
        CreatedSkill();
        CreatedSkill();

    }

    public void CreatedSkill()
    {
        x = GameSytstem.GetComponent<GameObject>().transform.position.x + 0.6f;
        y = GameSytstem.GetComponent<GameObject>().transform.position.y;

        doubleSlash = Instantiate(doubleSlash, new Vector3(x, y, 0), Quaternion.identity);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster_Script monsterStatus = Monster.GetComponent<Monster_Script>();
        Skills doubleSlash = new Skills(0, "Double Slash", 2.0f, 0.25f, 27.0f, 2, 1);

        if (CompareTag("skill"))
        {
            monsterStatus.nowHp -= (int)doubleSlash.damage;
        }
    }
}
