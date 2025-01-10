using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUiManager : MonoBehaviour
{

    #region Refarance Script
    public static GamePlayUiManager instance;
    #endregion

   
    #region Varibal
    [Header("Ref_Scrpit")]
    public GamePlay Ref_GamePlay;
    public Animation Ref_Animation;
    [Space]
    [Header("Btton_Ref")]
    public Transform Home_Btn;
    public Transform RePlay_Btn;
    public Transform Setting_Btn;
    public Transform Close_Btn;

    [Header("Audio_Clip")]
    public AudioClip BG_clip;
    public AudioClip Obstacl_Clip;
    public AudioClip UnObstcl_Clip;
    public AudioClip Click_Clip;
    [Space]
    [Header("Sprite")]
    public Sprite Obstacal_Sprite;
    public Sprite UnObsatacal_Sprite;

    [Space]
    [Header("GameOver_PopUp")]
    public GameObject GameOverPopUp_MainParent;
    public Transform GameOverPopUp_MainBG;
    public Image GameOver_AlphaBG;
    public TextMeshProUGUI ScoreText;

    [Space]
    [Header("Setting_PopUp")]
    public GameObject SettingPopUp_MainParent;
    public Transform SettingPopUp_MainBG;
    public Image SettingPopUp_AlphaBG;

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

    [Space]
    [Header("Touch Input Mathod")]
    public GameObject Left_Button;
    public GameObject Right_Button;


    [Space]
    [Header("Score")]
    public TextMeshProUGUI Score_Text;
    public TextMeshProUGUI CounDowan_Text;

    #endregion


    #region Unity Function
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        Ref_Animation = Animation.instance;
        GameOverPopUp_Close(false);
        SettingPopUp_Close(false);
    }
    #endregion 

    #region GameOver_PopUP Function
    public void GameOverPopUp_Open()
    {
        ScoreText.text = (StaticData.Score).ToString();
        Ref_Animation.PopupAnimation(true,GameOverPopUp_MainParent, GameOver_AlphaBG, GameOverPopUp_MainBG);
    }

    public void GameOverPopUp_Close(bool IsAnimated=true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(RePlay_Btn, EndAction: () =>
            Ref_Animation.PopupAnimation(false, GameOverPopUp_MainParent, GameOver_AlphaBG, GameOverPopUp_MainBG)
            );
        }
        {
            GameOverPopUp_MainParent.SetActive(false);
        }
    }
    #endregion


    #region Sound,Music Clip_Function
    public void Play_BGMusic()
    {
        Ref_GamePlay.Ref_SoundAndMusic.PlayMusic(BG_clip);
    }

    public void Play_TouchSound()
    {
        Ref_GamePlay.Ref_SoundAndMusic.PlayTouch(Click_Clip);
    }

    public void Play_Obstacal()
    {
        Ref_GamePlay.Ref_SoundAndMusic.PlaySound(Obstacl_Clip);
    }
    public void Play_Unobstacal()
    {
        Ref_GamePlay.Ref_SoundAndMusic.PlaySound(UnObstcl_Clip);
    }
    #endregion

    #region Sound and Music Function
    public void SetSound()
    {
        Sound_Slider.value = StaticData.Sound;
        if (StaticData.MuteSound == 0)
        {
            Sound_on(false);
        }
        else
        {
            Sound_Off(false);
        }
    }

    public void SetSound(float Volume)
    {
        Sound_Slider.value = Volume;
    }

    public void SetMusic()
    {
        Music_Slider.value = StaticData.Music;
        if (StaticData.MuteMusic == 0)
        {
            Music_on(false);
        }
        else
        {
            Music_off(false);
        }
    }
    public void SetMusic(float Volume)
    {
        Music_Slider.value = Volume;
    }
    public void Sound_Slider_Click()
    {
        Ref_GamePlay.Ref_SoundAndMusic.SetSound_Volume(Sound_Slider.value);

    }

    public void Music_Slider_Click()
    { 
        Ref_GamePlay.Ref_SoundAndMusic.SetMusic_Volume(Music_Slider.value);
    }

    public void Sound_on(bool IsAnimated = true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(Sound_ImageSorce.gameObject.transform,EndAction: ()=>
           {
               Ref_GamePlay.Ref_SoundAndMusic.SoundMute(false);
               Sound_ImageSorce.sprite = SoundOn_Sprite;
           } 
            );
        }
        else
        {
            Ref_GamePlay.Ref_SoundAndMusic.SoundMute(false);
            Sound_ImageSorce.sprite = SoundOn_Sprite;
        }
    }
    public void Sound_Off(bool IsAnimated=true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(Sound_ImageSorce.gameObject.transform, EndAction: () =>
            {
                Ref_GamePlay.Ref_SoundAndMusic.SoundMute(true);
                Sound_ImageSorce.sprite = SoundOff_Sprite;
            }
            );
        }
        else
        {
            Ref_GamePlay.Ref_SoundAndMusic.SoundMute(true);
            Sound_ImageSorce.sprite = SoundOff_Sprite;
        }
    }

    public void Music_on(bool IsAnimated = true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(Music_ImageSorce.gameObject.transform, EndAction: () =>
            {
                Ref_GamePlay.Ref_SoundAndMusic.MuiscMute(false);
                Music_ImageSorce.sprite = MusicOn_Sprite;
            }
            );
        }
        else
        {
            Ref_GamePlay.Ref_SoundAndMusic.MuiscMute(false);
            Music_ImageSorce.sprite = MusicOn_Sprite;
        }
    }
    public void Music_off(bool IsAnimated = true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(Music_ImageSorce.gameObject.transform, EndAction: () =>
            {
                Ref_GamePlay.Ref_SoundAndMusic.MuiscMute(true);
                Music_ImageSorce.sprite = MusicOff_Sprite;
            }
            );
        }
        else
        {
            Ref_GamePlay.Ref_SoundAndMusic.MuiscMute(true);
            Music_ImageSorce.sprite = MusicOff_Sprite;
        }
       
    }

    #endregion

    #region SoundPopUP Function
    public void SettingPopUp_Open()
    {
        SetSound();
        SetMusic();
        Ref_Animation.ButtonClickAnimation(Setting_Btn, EndAction: () =>
        Ref_Animation.PopupAnimation(true, SettingPopUp_MainParent, SettingPopUp_AlphaBG, SettingPopUp_MainBG)
        );
       
    }

    public void SettingPopUp_Close(bool IsAnimated = true)
    {
        if (IsAnimated)
        {
            Ref_Animation.ButtonClickAnimation(Close_Btn, EndAction: () =>
            Ref_Animation.PopupAnimation(false, SettingPopUp_MainParent, SettingPopUp_AlphaBG, SettingPopUp_MainBG)
            );
        }
        else
        {
            SettingPopUp_MainParent.SetActive(false);
        }
     
    }

    public void MutiTouchButton_On()
    {
        Left_Button.SetActive(true);
        Right_Button.SetActive(true);
    }
    public void MutiTouchButton_Off()
    {
        Left_Button.SetActive(false);
        Right_Button.SetActive(false);
    }
    #endregion

    #region GameOverPopUp Function
    public void ScoreDispaly(int Score)
    {
        Score_Text.text = Score.ToString();
    }

    public void CounDowan(string Text)
    {
        CounDowan_Text.text = Text;   
    }

    public void CounDowan_Set(bool Set)
    {
        CounDowan_Text.gameObject.SetActive(Set);
    }

    public void HomeBtnCLick()
    {
        Ref_Animation.ButtonClickAnimation(Home_Btn, EndAction: () =>
        {
            SceneManager.LoadScene(0);
        }
        );
    }
    #endregion
}
