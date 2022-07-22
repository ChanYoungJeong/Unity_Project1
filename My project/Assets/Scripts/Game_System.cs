using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_System : MonoBehaviour
{
    // Start is called before the first frame update

    //Player Moner
    public static int Gold;
    public int _Gold;   //To Visualize Gold Amount

    void Start()
    {
        Gold = 100000;
    }

    // Update is called once per frame
    void Update()
    {
        _Gold = Gold;
    }
}
