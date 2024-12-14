using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopUp : MonoBehaviour
{

    public SoundAndMusic Ref_SoundAndMusic;



    public void Start()
    {
        Ref_SoundAndMusic.MusicAudioSource.loop = true;

    }
    

   
    public void SoundOn()
    {
        StaticData.MuteSound = 0;
        StaticData.MuteTouch = 0;
        Ref_SoundAndMusic.SoundAudioSource.mute = false;
        Ref_SoundAndMusic.TouchAudioSource.mute = false;

    }
    public void SoundOff()
    {
        Ref_SoundAndMusic.SoundAudioSource.mute = true;
        Ref_SoundAndMusic.TouchAudioSource.mute = true;
        StaticData.MuteSound = 1;
        StaticData.MuteTouch = 1;
    }
    public void MusicOn()
    {
        Ref_SoundAndMusic.MusicAudioSource.mute = false;
        StaticData.MuteMusic = 0;
    }
    public void MusicOff()
    {
        Ref_SoundAndMusic.MusicAudioSource.mute = true;
        StaticData.MuteMusic = 1;
    }

    public void SetSound_Volume(float Volume)
    {
        StaticData.Sound = Volume;
        StaticData.Touch = Volume;

        Ref_SoundAndMusic.SoundAudioSource.volume = Volume;
        Ref_SoundAndMusic.TouchAudioSource.volume = Volume;
    }

    public void SetMusic_Volume(float Volume)
    {
        StaticData.Music = Volume;
        Ref_SoundAndMusic.MusicAudioSource.volume = Volume;
    }


}
