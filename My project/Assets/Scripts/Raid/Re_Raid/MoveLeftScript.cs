using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftScript: MonoBehaviour
{
    public float speed = 1.0f; // �̵� �ӵ�

    void Update()
    {
        // �������� �̵��ϴ� ����
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
