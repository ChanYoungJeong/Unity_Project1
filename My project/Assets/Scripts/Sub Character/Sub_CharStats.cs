using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_CharStats : MonoBehaviour
{
    public Dictionary<string, CharStats> SubChar = new Dictionary<string, CharStats>();


    private void Start()
    {
        Debug.Log("Sub_CharStats 스크립트 실행");
        Generate();
        Debug.Log("Sub_CharStats 스크립트 종료");
    }

    void Generate()
    {
        string name;

        name = "Rogue";
        SubChar.Add(name, new CharStats(name, 100, 100, 10, 1));
        

        /*name = "Sub 2";
        SubChar.Add(name, new CharStats(name, 300, 100, 20, 2));
*/

    }


}