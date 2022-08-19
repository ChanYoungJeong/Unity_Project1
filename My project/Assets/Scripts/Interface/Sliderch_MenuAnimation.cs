using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliderch_MenuAnimation : MonoBehaviour
{
	public GameObject PanelMune;

	public void ShowHideMenu()
	{
		if (PanelMune != null)
		{
			Animator animator = PanelMune.GetComponent<Animator>();
			if (animator != null)
			{
				bool isOpen = animator.GetBool("show");
				animator.SetBool("show", !isOpen);
			}
		}
	}
}
