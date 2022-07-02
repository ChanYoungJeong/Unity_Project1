using UnityEngine;

public class PlayerEvent : MonoBehaviour
{

    private float moveSpeed = 5.0f;                 // 이동속도
    //private Vector3 moveDirection = Vector3.zero;    // 이동 방향
    private Rigidbody2D rigid2D;
   

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Negative left, a: -1
        //Positive right, d: 1
        // Non : 0
        float x = Input.GetAxisRaw("Horizontal"); // 좌우 이동
        //Negative down, s: -1
        //Positive up, w: 1
        // Non : 0
        float y = Input.GetAxisRaw("Vertical");   // 상하 이동

        //이동방향 설정
        //moveDirection = new Vector3(x, y, 0);

        //새로운 위치 = 현재 위치 + (방향 + 속도)
        //trnasform.position = transform.position + new Vector3(1, 0, 0) * 1;
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

       
    }

}
 