using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_CharStats : MonoBehaviour
{
    public Dictionary<string, CharStats> SubChar = new Dictionary<string, CharStats>();


    private void Start()
    {
        Generate();
    }

    void Generate()
    {
        string name;

        name = "Rogue";
        SubChar.Add(name, new CharStats(name, 200, 100, 15, 2.5f, 1));

        name = "MagicCaster";
        SubChar.Add(name, new CharStats(name, 100, 500, 20, 3.5f, 1));

        name = "Priest";
        SubChar.Add(name, new CharStats(name, 100, 300, 10, 10, 1));

        name = "Archer";
        SubChar.Add(name, new CharStats(name, 100, 200, 15, 3, 1));

        name = "Alchemist";
        SubChar.Add(name, new CharStats(name, 100, 150, 30, 4, 1));

        name = "IceMagican";
        SubChar.Add(name, new CharStats(name, 100, 150, 25, 10, 1));
    }
}