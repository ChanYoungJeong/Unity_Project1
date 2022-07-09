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

    // Start is called before the first frame update
    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        leftPosX = -(xScreenHalfSize * 2);
        rightPosX = xScreenHalfSize * 2 * backgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Monster = GameObject.FindWithTag("Monster");
        if (Monster != null)
        {
            if(Monster.GetComponent<Stop_Monster>().Monster_Stop == false)
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

