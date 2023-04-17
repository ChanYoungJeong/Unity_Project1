using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // 이 오브젝트를 현재 씬에서 파괴되지 않게 설정
    }
}
