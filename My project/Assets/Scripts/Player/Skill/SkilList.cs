using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilList : MonoBehaviour
{
    Stat playerScript;
    public Dictionary<string, Skills> skilList = new Dictionary<string, Skills>();


    private void Start()
    {
        playerScript = gameObject.GetComponentInParent<Stat>();
        create();
    }

    public void create()
    {
        string name;
        float playerAttackDamage = playerScript.player_atkDamage * playerScript.player_criticalRate;

        name = "Double Slash";
        skilList.Add(name, new Skills(0, name, playerAttackDamage, 0.25f, 27.0f, 2, 1));

        name = "Fire Slash";
        skilList.Add(name, new Skills(1, name, 15.0f, 0.15f, 24.0f, 3, 1));

        name = "Fountain Of Blood";
        skilList.Add(name, new Skills(2, name, 3.0f, 0.2f, 24.0f, 10, 1));

        name = "Mega Slash";
        skilList.Add(name, new Skills(3, name, 100.0f, 1.0f, 30.0f, 1, 1));

        name = "Barrier";
        skilList.Add(name, new Skills(4, name, 20.0f, 1.0f, 5f, 1, 1));

    }
}
