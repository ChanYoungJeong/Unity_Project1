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
        SubChar.Add(name, new CharStats(name, 200, 100, 5, 2));

        name = "MagicCaster";
        SubChar.Add(name, new CharStats(name, 100, 500, 10, 3));

        name = "Priest";
        SubChar.Add(name, new CharStats(name, 100, 300, 10, 2));
    }
}