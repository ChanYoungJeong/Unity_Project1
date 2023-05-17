using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    public GameObject SettingPanel;
    public Slider musicBar;
    public Slider soundBar;
    float musicValue = 0.5f;
    float soundValue = 0.5f;

    public AudioMixer musicGroup;
    public AudioMixer soundGroup;
    public void Awake()
    {
        //Code for later when audio is added
        /*
        musicGroup.SetFloat("BGM", musicValue);
        soundGroup.SetFloat("SoundEffect", soundValue);
        */
    }


    public void ButtonOkay()
    {

        /*
        musicGroup.SetFloat("BGM", musicBar.value);
        soundGroup.SetFloat("SoundEffect", soundBar.value);
        */
        musicValue = musicBar.value;
        soundValue = soundBar.value;
        SettingPanel.SetActive(false);
    }

    public void ButtonQuit()
    {
        /*
        musicGroup.SetFloat("BGM", musicValue);
        soundGroup.SetFloat("SoundEffect", soundValue);
        */
        musicBar.value = musicValue;
        soundBar.value = soundValue;
        SettingPanel.SetActive(false);
    }
}
