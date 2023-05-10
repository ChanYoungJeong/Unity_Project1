using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    public int CurrentStage;

    void Awake()
    {
        /*if (Game_System.Stage%CurrentStage ==0)
        {
            ChangeAnimation();
        }*/
    }

    void ChangeAnimation()
    {
        /* GetComponentInChildren<Animator>().runtimeAnimatorController =
         (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate
         (Resources.Load("Ani\\HorseNewController", typeof(RuntimeAnimatorController)));*/

        

    }
}
