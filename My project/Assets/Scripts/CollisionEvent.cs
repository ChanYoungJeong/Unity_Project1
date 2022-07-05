using System.Collections;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{

    private Color color;
    private SpriteRenderer spriteRenderer;
    private float starTime;
    private int HP = 100;
    public int check = 0;

    private void Start()
    {
        starTime = Time.time;
    }

    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (check == 0)
        {
            check = 1;
            StartCoroutine(WaitForIt());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    IEnumerator WaitForIt()
    {
        
        yield return new WaitForSeconds(1);
        if (HP >= 0)
        {
            HP -= 10;
            Debug.Log(HP);
        }
        check = 0;
    }
}
