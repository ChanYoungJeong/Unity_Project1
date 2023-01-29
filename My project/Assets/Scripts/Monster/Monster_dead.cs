using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_dead : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject,1.0f);
    }
}
