using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public Slider HP_bar;

<<<<<<< Updated upstream
    public float maxHp = 100;        // 몬스터 총 HP
    public float curHp = 100;         // 몬스터 현제 HP
=======
    private float maxHp = 100;
    private float curHp = 100;

    public GameObject healthBar;

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
>>>>>>> Stashed changes

    private void Awake()
    {
        HP_bar = GetComponent<Slider>();
    }
}
