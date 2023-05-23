using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die_Sound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip[] audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        audioSource.clip = audioClip[Random.Range(0, audioClip.Length - 1)];
        audioSource.Play();
        
    }
}
