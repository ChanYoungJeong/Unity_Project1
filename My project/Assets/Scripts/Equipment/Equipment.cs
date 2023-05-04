using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment
{
    public int code;
    public string name;
    public string grade;
    public int stat1;
    public int stat2;
    public string type;
    public int upgrade;

    public Equipment(int _code, string _name, string _grade, int _stat1, int _stat2, string _type)
    {
        code = _code;
        name = _name;
        grade = _grade;
        stat1 = _stat1;
        stat2 = _stat2;
        type = _type;
        upgrade = 0;
    }
}
