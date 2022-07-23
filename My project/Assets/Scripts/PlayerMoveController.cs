using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5.0f; //�÷��̾� �̵� �ӵ�

    float horizontal; //����, ������ ���Ⱚ�� �޴� ����

    private void FixedUpdate() // �÷��̾� �̵��� �׻� �߿��ϰ� �̷�����Ƿ� Fixed Update�� �̿�
    {
        Move(); //�÷��̾� �̵�

    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");

        Vector3 dir = horizontal * Vector3.right; //������ �ڷ����� ���߱� ���� ������ ���ο� Vector3 ����

        this.transform.Translate(dir * moveSpeed * Time.deltaTime); //������Ʈ �̵� �Լ�
    }
}