using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSkillMenuAnim : MonoBehaviour
{
	public GameObject PanelMune;

	public void ShowHideMenu()
	{
		Debug.Log("스킬메뉴 버튼 클릭 됨");
		if(PanelMune != null) {
			Animator animator = PanelMune.GetComponent<Animator>();
			if(animator != null) {
				bool isOpen = animator.GetBool("show");
				animator.SetBool("show", !isOpen);
			}
		}
	}
}
