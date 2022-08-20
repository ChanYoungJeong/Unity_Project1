using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public int code;
    public string name;
    public string grade;
    public int stat1;
    public int stat2;

    public Equipment(int _code, string _name, string _grade, int _stat1, int _stat2)
    {
        code = _code;
        name = _name;
        grade = _grade;
        stat1 = _stat1;
        stat2 = _stat2;
    }
}
