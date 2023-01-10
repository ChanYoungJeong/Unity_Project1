using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCoolTimeBar : MonoBehaviour
{
    public Transform transformSubchar;



    void Update()
    {
        this.transform.position = new Vector3(transformSubchar.position.x, transformSubchar.position.y + 1.6f,
                                                    transformSubchar.position.z);
    }
}
