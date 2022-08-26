using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilList : MonoBehaviour
{
    public List<Skills> skliiList = new List<Skills>();

    private void Start()
    {
        create();
    }

    public void create()
    {
        Skills doubleSlash = new Skills(0, "Double Slash", 2.0f, 0.25f, 27.0f, 2, 1);
        Skills fireSlash = new Skills(1, "Fire Slash", 0.5f, 0.15f, 24.0f, 7, 1);
        Skills fountainOfBlood = new Skills(2, "fountain of blood", 0.3f, 0.2f, 24.0f, 10, 1);
        Skills Darkness = new Skills(3, "Darkness", 3.0f, 1.0f, 30.0f, 1, 1);

        skliiList.Add(doubleSlash);
        skliiList.Add(fireSlash);
        skliiList.Add(fountainOfBlood);
        skliiList.Add(Darkness);
    }
}
