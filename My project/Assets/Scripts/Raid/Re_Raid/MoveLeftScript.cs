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
}
