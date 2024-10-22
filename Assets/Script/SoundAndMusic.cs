using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class SoundAndMusic : MonoBehaviour
{
    public AudioSource SoundAudioSource;
    public AudioSource MusicAudioSource;

    [HideInInspector]
    public static SoundAndMusic instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetSound_Volume(StaticData.Sound);
        SetMusic_Volume(StaticData.Music);
    }

    public void PlaySound(AudioClip clip)
    { 
        SoundAudioSource.clip = clip;
        SoundAudioSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicAudioSource.clip = clip;
        MusicAudioSource.Play();
    }

    public void SoundMute(bool mute) {
    
        SoundAudioSource.mute = mute;
    }

    public void MuiscMute(bool mute) 
    {
        MusicAudioSource.mute = mute;
    }

    public void SetSound_Volume(float Volume)
    {
        SoundAudioSource.volume = Volume;
    }

    public void SetMusic_Volume(float Volume) 
    { 
        MusicAudioSource.volume= Volume;
    }
}
