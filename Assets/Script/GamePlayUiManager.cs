using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUiManager : MonoBehaviour
{

    //  public static GamePlayUiManager instance;
    // Start is called before the first frame update
    #region Varibal
    [Header("Ref_Scrpit")]
    public GamePlay Ref_GamePlay;

    [Header ("Audio_Clip")]
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
    public GameObject GameOverPopUP;
    public TextMeshProUGUI ScoreText;

    [Space]
    [Header("Setting_PopUp")]
    public GameObject SettingPopUp;
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
    public Image Tocuch_ImageSorce;
    public Sprite TouchOn_Sprite;
    public Sprite TouchOff_Sprite;
    public Image Button_ImageSorce;
    public Sprite ButtonOn_Sprite;
    public Sprite ButtonOff_Sprite;


    #endregion


    #region GameOver_PopUP Function
    public void GameOverPopUp_Open()
    {
        GameOverPopUP.SetActive (true);
    }

    public void GameOverPopUp_Close()
    {
        GameOverPopUP.SetActive(false);
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
        Ref_GamePlay.Ref_SoundAndMusic.SetSound_Volume(Sound_Slider.value);
        //Ref_GamePlay.Ref_SoundAndMusic.Settouch_Volume(Sound_Slider.value);

    }

    public void SetMusic()
    {
        Ref_GamePlay.Ref_SoundAndMusic.SetMusic_Volume(Sound_Slider.value);
    }

    public void Sound_Slidar()
    { 
        StaticData.Sound = Sound_Slider.value;
        StaticData.Touch = Sound_Slider.value;
    }

    public void Music_Slidar()
    {
        StaticData.Music = Music_Slider.value;  
    }

    public void Sound_on()
    { 
        Sound_ImageSorce.sprite = SoundOn_Sprite; 
    }
    public void Sound_Off()
    { 
        Sound_ImageSorce.sprite = SoundOff_Sprite;
    }

    public void Music_on()
    {
        Music_ImageSorce.sprite = MusicOn_Sprite;
    }
    public void Music_off()
    {
        Music_ImageSorce.sprite = MusicOff_Sprite;
    }

    #endregion

    #region Touch Mathod Function
    public void Touchon_Method()
    {
        Tocuch_ImageSorce.sprite = TouchOn_Sprite;
        Button_ImageSorce.sprite = ButtonOff_Sprite;

    }

    public void Touchoff_Method()
    {
        Tocuch_ImageSorce.sprite = TouchOff_Sprite;
        Button_ImageSorce.sprite = ButtonOn_Sprite;
    }

    #endregion

}
