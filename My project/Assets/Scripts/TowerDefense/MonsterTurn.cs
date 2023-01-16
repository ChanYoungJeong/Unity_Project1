using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTurn : MonoBehaviour
{
    Rigidbody2D rigid;
    Transform trans;
    GameObject GameOverPanel;

    public float moveSpeed;

    public bool down = false;
    public bool up = false;
    public bool letf = true;
    void Awake()
    {
        trans = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        GameOverPanel = GameObject.Find("Panel :: GameOver");
        
    }
    private void Start()
    {
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {

        if (letf)
        {
            Vector3 curPos = trans.position;
            Vector3 nestPos = new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;

            trans.position = curPos + nestPos;
        }
        else if (up)
        {
            Vector3 curPos = trans.position;
            Vector3 nestPos = new Vector3(0, moveSpeed, 0) * Time.deltaTime;

            trans.position = curPos + nestPos;
        }
        else if (down)
        {
            Vector3 curPos = trans.position;
            Vector3 nestPos = new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

            trans.position = curPos + nestPos;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "WayPoint 1" || collision.name == "WayPoint 5"
            || collision.name == "WayPoint 9" || collision.name == "WayPoint 13") // down
        {
            down = true;
            up = false;
            letf = false;
        }
        else if(collision.name == "WayPoint 2" || collision.name == "WayPoint 4" // letf
            || collision.name == "WayPoint 6" || collision.name == "WayPoint 8"
            || collision.name == "WayPoint 10" || collision.name == "WayPoint 12"
            || collision.name == "WayPoint 14")
        {
            down = false;
            up = false;
            letf = true;
        }
        else if(collision.name == "WayPoint 3" || collision.name == "WayPoint 7" // up
            || collision.name == "WayPoint 11")
        {
            down = false;
            up = true;
            letf = false;
        }
        else if(collision.name == "Goal")
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }


}
