using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenUiManagar : MonoBehaviour
{
    public SoundAndMusic Ref_SoundAndMusic;
    public ButtonAnimation Ref_ButtonAnimation;


    public GameObject Play;

    [Header("SettingPopUp")]
    public GameObject SettingPopUp;
    [Space]
    [Header("Audio_Clip")]
    public AudioClip BG_clip;
    public AudioClip Click_Clip;
    [Space]
    [Header("TouchInPut")]
    public Image SingalTouch_ImageSorce;
    public Sprite On_Sprite;
    public Image MultiTouch_ImageSorce;
    public Sprite Off_Sprite;
    [Space]
    [Header("Sound Componat")]
    public Slider Sound_Slider;
    public Image Sound_ImageSorce;
    public Sprite SoundOn_Sprite;
    public Sprite SoundOff_Sprite;
    [Space]
    [Header("Music Componat")]
    public Slider Music_Slider;
    public Image Music_ImageSorce;
    public Sprite MusicOn_Sprite;
    public Sprite MusicOff_Sprite;


    public void Start()
    {
      
        Play_BGMusic();
    }

    public void SettingPopUp_Open()
    {
        SetSound();
        SetMusic();
        SetInputMethod();

        SettingPopUp.SetActive(true);
    }
    public void SettingPopUP_Close()
    {
        SettingPopUp.SetActive(false);
    }

    public void PlayBtnCLick()
    {
        Ref_ButtonAnimation.ButtonClickAnimation(Play.transform, EndAction: () => {
            SceneManager.LoadScene(1);
        }
        );
    }

    public void Touch_On()
    {
       // Debug.Log("Singal");
        StaticData.Player_Touch = 0;
        SingalTouch_ImageSorce.sprite= On_Sprite;
        MultiTouch_ImageSorce.sprite = Off_Sprite;
    }
    public void Touch_Off()
    {
       // Debug.Log("Multi");
        StaticData.Player_Touch = 1;
        SingalTouch_ImageSorce.sprite = Off_Sprite;
        MultiTouch_ImageSorce.sprite = On_Sprite;
    }

    public void SetSound()
    {
        Sound_Slider.value = StaticData.Sound;
        if (StaticData.MuteSound == 0)
        {
            Sound_on();
        }
        else
        {
            Sound_Off();
        }
    }


    public void SetMusic()
    {
        Music_Slider.value = StaticData.Music;
        if (StaticData.MuteMusic == 0)
        {
            Music_on();
        }
        else
        {
            Music_off();
        }
    }
   
    public void Sound_Slider_Click()
    {
       
        Ref_SoundAndMusic.SetSound_Volume(Sound_Slider.value);

    }

    public void Music_Slider_Click()
    {
       
      Ref_SoundAndMusic.SetMusic_Volume(Music_Slider.value);
    }

    public void Sound_on()
    {
      
        Ref_SoundAndMusic.SoundMute(false);
        Sound_ImageSorce.sprite = SoundOn_Sprite;


    }
    public void Sound_Off()
    {
        Ref_SoundAndMusic.SoundMute(true);
        Sound_ImageSorce.sprite = SoundOff_Sprite;
       
    }

    public void Music_on()
    {
       Ref_SoundAndMusic.MuiscMute(false);
        Music_ImageSorce.sprite = MusicOn_Sprite;
        
    }
    public void Music_off()
    {
        Ref_SoundAndMusic.MuiscMute(true);
        Music_ImageSorce.sprite = MusicOff_Sprite;
    }

    public void SetInputMethod()
    {
        if (StaticData.Player_Touch == 0)
        {
            Touch_On();
        }
        else
        {
            Touch_Off();
        }
    }

    public void Play_BGMusic()
    {
       Ref_SoundAndMusic.PlayMusic(BG_clip);
    }

    public void Play_TouchSound()
    {
        Ref_SoundAndMusic.PlayTouch(Click_Clip);
    }

}
