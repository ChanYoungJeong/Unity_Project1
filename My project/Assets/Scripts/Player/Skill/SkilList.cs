using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilList : MonoBehaviour
{
    PlayerScript playerScript;
    public Dictionary<string, Skills> skilList = new Dictionary<string, Skills>();


    private void Start()
    {
        playerScript = gameObject.GetComponentInParent<PlayerScript>();
        create();
    }

    public void create()
    {
        string name;


        float doubleSlashDamage = playerScript.atkDmg * playerScript.critical;
        name = "Double Slash";
        skilList.Add(name, new Skills(0, name, doubleSlashDamage, 0.25f, 5.0f, 2, 1));


        name = "Fire Slash";
        skilList.Add(name, new Skills(1, name, 0.5f, 0.15f, 24.0f, 7, 1));


        name = "Fountain Of Blood";
        skilList.Add(name, new Skills(2, name, 0.3f, 0.2f, 24.0f, 10, 1));


        name = "Darkness";
        skilList.Add(name, new Skills(3, name, 3.0f, 1.0f, 30.0f, 1, 1));


    }
}
