using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopUp : MonoBehaviour
{
    [Header ("Slider")]
    public Slider SoundSlider;
    public Slider MusicSlider;
    [Space]
    [Header("ImageParent")]
    public Image SoundImage;
    public Image MusicImage;
    [Space]
    [Header("ImageSprite")]
    public Sprite SoundSprite;
    public Sprite MusicSprite;
    public Sprite MuteSoundSprite;
    public Sprite MuteMusicSprite;
    [Space]
    [Header("Popup Refanace")]
    public GameObject PopUp;
    public GameObject PopUpBg;


    //SoundAndMusic SoundMusic;

    public void Start()
    {
        SoundSlider.value = StaticData.Sound;
        MusicSlider.value = StaticData.Music;
        SetSoundAndMusic();

      //  SoundMusic = SoundAndMusic.instance;

    }
    

    public void ButtonControl(string button)
    {

        switch (button) {
            case "Close":
               /* AnimationManager.Scale(PopUpBg.transform, 0.5f, EndPostion: Vector3.zero, StartPostion: Vector3.one, ease: Ease.InFlash,EndAction:
                    () => {
                        PopUpBg.transform.localScale= Vector3.one;
                        PopUp.SetActive(false);
                    }
                    ); */
                //PopUp.SetActive(false);
                break;
            case "Sound":
                Sound_Slidar();
                break;
            case "Music":
                Music_Slidar();
                break;
            case "Sound_Mute":
                Sound_Icon();
                break;
            case "Music_Mute":
                Music_Icon();
                break;
  
        }
    }
    public void Sound_Slidar()
    {
        StaticData.Sound = SoundSlider.value;
        //soundandmusic.SoundAudioSource.volume = SoundSlider.value;
        SoundAndMusic.instance.SetSound_Volume(SoundSlider.value);
        if (StaticData.Sound == 0)
        {
            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }
    }

    public void Music_Slidar()
    {
        StaticData.Music = MusicSlider.value;
        SoundAndMusic.instance.SetMusic_Volume(MusicSlider.value);
       // soundandmusic.MusicAudioSource.volume = MusicSlider.value;
        if (StaticData.Music == 0)
        {
            MusicMute(true);
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Music_Icon()
    {
        if (StaticData.MuteMusic == 0)
        {
            MusicMute(true); 
        }
        else
        {
            MusicMute(false);
        }
    }

    public void Sound_Icon()    
    {
        if (StaticData.MuteSound == 0)
        {
            SoundMute(true);
        }
        else
        {
            SoundMute(false);
        }

    }

    public void SoundMute(bool mute)
    {
     
        if (mute)
        {
            StaticData.MuteSound = 1;
            SoundImage.sprite = MuteSoundSprite;
            SoundAndMusic.instance.SoundMute(true);
        }
        else
        {
            StaticData.MuteSound = 0;
            SoundImage.sprite = SoundSprite;
            SoundAndMusic.instance.SoundMute(false);
        }
    }

    public void MusicMute(bool mute)
    {
        if (mute)
        {
            StaticData.MuteMusic = 1;
            MusicImage.sprite = MuteMusicSprite;
            SoundAndMusic.instance.MuiscMute(true);
        }
        else
        {
            StaticData.MuteMusic = 0;
            MusicImage.sprite = MusicSprite;
            SoundAndMusic.instance.MuiscMute(false);
        }
    }

    public void SetSoundAndMusic()
    {
        if (StaticData.MuteSound == 0)
        {
            SoundMute(false);
        }
        else
        {
            SoundMute(true);
        }

        if (StaticData.MuteMusic == 0)
        {
            MusicMute(false);
        }
        else
        {
            MusicMute(true);
        }
    }
}
