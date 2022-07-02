using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("�浹�Ǿ����ϴ�");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
