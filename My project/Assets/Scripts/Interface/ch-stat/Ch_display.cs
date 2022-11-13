using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ch_display : MonoBehaviour
{
    public PlayerScript Player_Object;
    public Text text1;
    public Text text2;
    public float pl_atk;
    public int pl_level;

    public void update_stat()
    {
        pl_atk = Player_Object.atkDmg;
        pl_level = Player_Object.lv;
    }

    public void update_statText()
    {
        text1.text = pl_atk.ToString();
        text2.text = pl_level.ToString();
    }
    private void Update()
    {
        update_stat();
        update_statText();
    }
}
