using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField]
    private Slider HP_bar;

    private float maxHp = 100;
    private float curHp = 100;
    float imsi;
    // Start is called before the first frame update
    void Start()
    {
        HP_bar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curHp -= 10;
        }

    }

    private void HandleHp()
    {
        HP_bar.value = Mathf.Lerp(HP_bar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }
}
