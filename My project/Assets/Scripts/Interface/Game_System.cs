using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_System : MonoBehaviour
{
    public static int Gold;
    public int _Gold;   //To Visualize Gold Amount
    public Text displyGold;

    public static int Diamond;
    public Text displayDiamond;

    public static int Stage = 0;
    public static float StageDelay = 2.5f;
    public static bool bossStage;
    [SerializeField]
    int bossStageRotation = 5;
    public Text Stage_Text;

    public Transform DamageTextHolder;

    // Update is called once per frame
    void Update()
    {
        _Gold = Gold;
        displyGold.text = Gold.ToString() + "G";
        Stage_Text.text = "Stage " + Stage;

        displayDiamond.text = Diamond.ToString();

        if((Stage + 1) % bossStageRotation == 0)
        {
            bossStage = true;
        }
        else
        {
            bossStage = false;
        }
    }

    public static void setParentHolder(Transform transform)
    {
        if (GameObject.FindWithTag("GameManager"))
        {
            transform.SetParent(GameObject.FindWithTag("GameManager").transform.Find("ProjectileHolder"));
        }
    }

}


       


