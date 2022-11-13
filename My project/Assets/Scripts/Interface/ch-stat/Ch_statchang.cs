using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch_statchang : MonoBehaviour
{
    public Text CH_LEVEL;
    public Text CH_ATK;


    public void Showch(string _CH_LEVEL, string _CH_ATK)
    {
        CH_ATK.text = _CH_ATK;
        CH_LEVEL.text = _CH_LEVEL;
    }
}
