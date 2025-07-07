using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string soundID;
    public AudioClip[] clip;
}
public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        foreach (var soundEffect in soundEffects)
        {
            if (soundEffect.soundID == name)
            {
                return soundEffect.clip[Random.Range(0, soundEffect.clip.Length)];
            }
        }
        return null;
    }
    
}
