using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌하면 표시한다 
public class AttackMotion : MonoBehaviour
{
	Animator animator;
	Rigidbody2D myrigidbody;
	[SerializeField]
	float speed = 3;

	void Start()
	{
		animator = GetComponent<Animator>();
		myrigidbody = GetComponent<Rigidbody2D>();
	}



	private void update()
	{
		if (Input.GetKey(KeyCode.Z))//(Input.GetMouseButtonDown(0))
		{
			animator.SetTrigger("AttackMotion");
		}

	}
}