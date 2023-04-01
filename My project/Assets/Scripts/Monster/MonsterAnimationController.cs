using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (Game_System.Stage >= 2 && Game_System.Stage < 20)
        {
            ChangeAnimation();
        }
    }

    void ChangeAnimation()
    {
        GetComponentInChildren<Animator>().runtimeAnimatorController =
        (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate
        (Resources.Load("Ani\\Idle_0", typeof(RuntimeAnimatorController)));
    }
}
