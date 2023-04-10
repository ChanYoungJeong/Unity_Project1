using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    public Slider expSlider;
    Stat playerStat;
    float maxExp;
    float curExp;

    // Start is called before the first frame update
    void Awake()
    {
        playerStat = GetComponent<Stat>();
    }

    private void Start()
    {
        expSlider.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        maxExp = playerStat.player_maxExp;
        curExp = playerStat.player_nowExp;
        expSlider.value = Mathf.Lerp(expSlider.value, curExp / maxExp, Time.deltaTime * 5f);
    }
}
