using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI : MonoBehaviour
{
    public Slider HP_bar;

    public float maxHp = 100;        // ���� �� HP
    public float curHp = 100;         // ���� ���� HP

    private void Awake()
    {
        HP_bar = GetComponent<Slider>();
    }
}
