using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text buttonText;
    // Start is called before the first frame update
    int scoreButton;
    int up_gold;
    public int gold;
    private void Awake()
    {
        scoreButton = 0;
        up_gold = 20000;
    }

    // Update is called once per frame
    private void Update()
    {
        buttonText.text = scoreButton.ToString();
    }

    public void OnClickBasicButton()
    {
        if (gold > up_gold)
        {
            scoreButton = scoreButton + 1;
            Debug.Log(scoreButton);
            gold = gold - up_gold;
            Debug.Log(gold);
        }
           
    }
}

