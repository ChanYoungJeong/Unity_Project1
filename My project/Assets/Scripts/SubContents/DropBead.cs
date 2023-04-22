using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBead : MonoBehaviour
{
    [Header("���� ������ �뵵")]
    public GameObject Bead;
    public float dropRate;
    int dropCount;

    // Start is called before the first frame update
    void Start()
    {
        dropCount = 1;
    }

    //���⼭���ʹ� SUB Content��
    public void dropBead()
    {
        if (dropCount > 0)
        {
            dropCount--;
            int dropProb = Random.Range(1, 100);
            if (dropProb < dropRate)
                Instantiate(Bead, this.transform.position, this.transform.rotation);

            int TypeProb = Random.Range(1, 4);
            string type = "";

            if (TypeProb == 1)
                type = "Archer";
            else if (TypeProb == 2)
                type = "Rogue";
            else if (TypeProb == 3)
                type = "Wizzard";

            Bead.GetComponent<GetAsderBead>().BeadType = type;
        }
    }
}
