using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �浹�ϸ� ǥ���Ѵ� 
public class Attack : MonoBehaviour
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
		if (Input.GetMouseButtonDown(0))
		{
			animator.SetTrigger("Attack");
		}

	}