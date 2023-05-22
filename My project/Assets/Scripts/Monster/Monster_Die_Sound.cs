using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die_Sound : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip[] audioClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioClip[Random.Range(0, audioClip.Length - 1)];
        audioSource.Play();
        
    }
}
