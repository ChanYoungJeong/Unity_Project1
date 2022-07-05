using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public Slider HP_bar;

    public float maxHp = 100;        // 몬스터 총 HP
    public float curHp = 100;         // 몬스터 현제 HP

    private void Awake()
    {
        HP_bar = GetComponent<Slider>();
    }
}
