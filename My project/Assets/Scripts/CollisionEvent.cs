using System.Collections;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{

    private Color color;
    private SpriteRenderer spriteRenderer;
    private float starTime;
    private int HP = 5;
    public int check = 0;
    public float wait_time = 2.0f;

    private void Start()
    {
        starTime = Time.time;
    }

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // ������Ʈ�� �꿴�� ��
    {
        spriteRenderer.color = Color.red;
        
    }

    private void OnCollisionStay2D(Collision2D collision) // ���̰� ���� ��
    {
        if(check == 0){
            check = 1;
            StartCoroutine(WaitForIt());
        }

    }

    private void OnCollisionExit2D(Collision2D collision) // �������� ��
    {
        spriteRenderer.color = Color.white;
    }

    IEnumerator WaitForIt()
    {
        
        if (HP >= 0)
        {
            HP -= 1;
            Debug.Log(HP);
        }
        yield return new WaitForSeconds(wait_time);
        check = 0;
    }
}
