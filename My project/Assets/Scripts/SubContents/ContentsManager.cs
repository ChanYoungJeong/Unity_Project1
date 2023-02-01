using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsManager : MonoBehaviour
{
    public static ContentsManager instans;

    public PlayerScript player;
    public PoolManager pool;
    public Enemy[] enemy;

    private void Awake()
    {
        instans = this;
    }
}
