using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject button;
	public GameObject skillprefab1;
	public Skill_Manager skiliManager;

	private void Start()
	{
		CreateSkill();
	}
	public void CreateSkill()
	{
		GameObject skill1 = Instantiate(skillprefab1);
		skill1.transform.position =new Vector2(20.0f, 0);

		

	}

	public void Attack(Skills skills, GameObject monster)
	{
		Monster_Script mon = monster.GetComponent<Monster_Script>();
		mon.nowHp -= (int)skiliManager.skillLists[0].damage;
		Debug.Log(mon.nowHp);
	}



}
