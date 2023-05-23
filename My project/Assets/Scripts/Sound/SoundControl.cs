using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public AudioSource[] soundEffect;
    public Slider soundOption;
    public Slider sound;

    private void Update()
    {
        if (soundOption.value == 1)
        {
            for (int i = 0; i < soundEffect.Length; i++)
            {
                soundEffect[i].volume = sound.value / 100f;
            }
        }
        else
        {
            for (int i = 0; i < soundEffect.Length; i++)
            {
                soundEffect[i].volume = 0;
            }
        }
    }

}
