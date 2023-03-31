using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this.gameObject, 1.0f);
    }

}
