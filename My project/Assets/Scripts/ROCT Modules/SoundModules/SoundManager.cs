using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    private static Dictionary<string, AudioClip> data = new Dictionary<string, AudioClip>();
    public static void AddSound(AudioClip audio) => data.Add(audio.name, audio);
    public static AudioClip GetSound(string name) => data[name];

}
