using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftScript: MonoBehaviour
{
    public float speed = 1.0f; // 이동 속도

    void Update()
    {
        // 왼쪽으로 이동하는 로직
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EndLine")
        {
            speed = 0;
        }
    }
}
