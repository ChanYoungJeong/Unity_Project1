using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Raid : MonoBehaviour
{
    public GameObject endLine;
    Animator animator;
    MoveLeftScript MoveLeftScript;

    private void Awake()
    {
        MoveLeftScript = GetComponentInParent<MoveLeftScript>();
        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
    }

    void StopRaid()
    {
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == endLine)
        {
            animator.SetTrigger("Boss_SkillNormal");
        }
    }
}
