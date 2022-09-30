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
        SubChar.Add(name, new CharStats(name, 100, 100, 5, 3));


        /*name = "Sub 2";
        SubChar.Add(name, new CharStats(name, 300, 100, 20, 2));
*/
        name = "Priest";
        SubChar.Add(name, new CharStats(name, 80, 150, 3, 1));

    }


}