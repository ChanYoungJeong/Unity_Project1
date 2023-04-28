using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Raid : MonoBehaviour
{
    public GameObject endLine;
    public GameObject overBtn;
    Animator animator;

    private void Awake()
    {
        overBtn.SetActive(false);

        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
    }

    void SropRaid()
    {
        Debug.Log("정지");
        //Time.timeScale = 0;

        overBtn.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("공격 실행");
            animator.SetTrigger("Boss_SkillNormal");
        }
    }
}
