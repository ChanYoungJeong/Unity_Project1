using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeSettings : MonoBehaviour
{

    private void Awake()
    {
        AudioClip[] audioClip = Resources.LoadAll<AudioClip>("Sounds");

        for (int i = 0; i < audioClip.Length; i++)
        {
            Debug.Log(audioClip[i].name);
            SoundManager.AddSound(audioClip[i]);
        }
    }
}
