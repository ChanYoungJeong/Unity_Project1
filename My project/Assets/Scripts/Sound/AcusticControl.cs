using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcusticControl : MonoBehaviour
{
    public AudioSource mainMusic;


    public Slider musicOption;
    public Slider music;



    private void Update()
    {
        if(musicOption.value == 1)
        {
            mainMusic.volume = music.value/100f;

        }
        else
        {
            mainMusic.volume = 0f;
        }

    }
}
