using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Scrolling : MonoBehaviour
{
    GameObject Monster;
    bool Monster_Stop_Check;
    public float speed;

    public Transform[] backgrounds;

    float leftPosX = 0f;
    float rightPosX = 0f;
    float xScreenHalfSize;
    float yScreenHalfSize;

    //Most left Screen position variable
    float leftBackground_x;
    float leftBackground_y;

    // Start is called before the first frame update
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;


        for (int i = 0; i < backgrounds.Length; i++)
        {
            float spritex = backgrounds[i].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            float spritey = backgrounds[i].GetComponent<SpriteRenderer>().sprite.bounds.size.y;
            backgrounds[i].transform.localScale = new Vector2(((xScreenHalfSize * 2) / spritex),(yScreenHalfSize * 2) / spritey);
            backgrounds[i].position = new Vector3(leftPosX + 2 * xScreenHalfSize * i, 0, 1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Monster = GameObject.FindWithTag("Monster");
        if (Monster != null)
        {
            if(!Battle_Situation_Trigger.On_Battle)
            {
                Scroll_BackGrounds();
            }
            else
            {
                return;
            }
        }

    }

    private void Scroll_BackGrounds()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            if (backgrounds[i].position.x < leftPosX)
            {
                
                Vector3 nextPos = backgrounds[i].position;
                nextPos = new Vector3(nextPos.x + rightPosX, nextPos.y, nextPos.z);
                backgrounds[i].position = nextPos;
            }
        }
    }

}

