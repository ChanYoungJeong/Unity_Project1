using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_ani : MonoBehaviour
{
	
	public GameObject playersettingbutton;

	public void ShowHideMenu()
	{
		if (playersettingbutton != null)
		{
			Animator animator = playersettingbutton.GetComponent<Animator>();
			if (playersettingbutton != null)
			{
				bool isOpen = animator.GetBool("show");
				animator.SetBool("show", !isOpen);
			}
		}
	}
}