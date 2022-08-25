using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randombutton : MonoBehaviour
{
    public Text randomButtonText;
  
    int randomButton;
    int randomgold;
   
    bool click = false;

    int my_gold;
    int random_item;
    
    private void Awake()
    {
        randomButton = 0;
        randomgold = 5000;
      
        //my_gold = Game_System.Gold;
    }

    // Update is called once per frame
    private void Update()
    {

        randomButtonText.text = randomButton.ToString();
    }

    public void ramdom_chooseButton()
    {
        if (randomButton == 0)
        {
            my_gold = Game_System.Gold;
        }
        Debug.Log("now_gold : " + my_gold);
        Debug.Log("randomgold : " + randomgold);
        click = true;
        if (click)
        {
            if (my_gold > randomgold)
            {
                randomButton += 1;
                my_gold -= randomgold;
                Debug.Log("my_gold : " + my_gold);
                Debug.Log("randomButton" + randomButton);
                click = false;
            }
        }

    }
    
}
