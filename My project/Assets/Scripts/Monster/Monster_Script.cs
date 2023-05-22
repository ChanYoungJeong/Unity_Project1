using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public string monsterType;
    public float maxHp;
    public float nowHp;
    public float atkDmg;
    public float atkSpeed;
    public int Golds;
    public int Exp;

    AudioSource audioSource;
    public AudioClip[] voice;

    private float timer = 1;
    private float time;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > timer)
        {
            time = 0;
            audioSource.clip = voice[Random.Range(0, voice.Length - 1)];
            audioSource.Play();
        }
    }
}
