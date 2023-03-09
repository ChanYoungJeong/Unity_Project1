using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDestroy : MonoBehaviour
{
    private void Start()
    {
        Archerskill();
        Invoke("DestroyScript", 2.0f);
    }

    void Archerskill()
    {

    }

    void DestroyScript()
    {
        Destroy(gameObject);
    }
}
