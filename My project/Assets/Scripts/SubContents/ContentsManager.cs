using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentsManager : MonoBehaviour
{
    public static ContentsManager instans;
    public static bool startContent;

    public PlayerScript player;
    public PoolManager pool;
    public Enemy[] enemy;


    private void Awake()
    {
        instans = this;
        startContent = false;
    }

    public void StartContent()
    {
        startContent = true;
    }
}
