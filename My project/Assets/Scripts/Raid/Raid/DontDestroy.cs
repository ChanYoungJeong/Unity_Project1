using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var objs = FindObjectsOfType<DontDestroy>();
        if (objs.Length == 1)
        { 
        DontDestroyOnLoad(gameObject);
        }
    }
}
