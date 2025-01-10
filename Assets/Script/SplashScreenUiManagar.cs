
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenUiManagar : MonoBehaviour
{
    #region Varibal & Refance Sciprt
    public SoundAndMusic Ref_SoundAndMusic;
    public Animation Ref_Animation;
   

    [Header("Button_Ref")]
    public GameObject Play_Btn;
    public GameObject Close_Btn;
    public GameObject Setting_Btn;

    [Space]
    [Header("SettingPopUp")]
    public Transform SettingPopUp_MainBG;
    public Image SettingPopUp_AlphaBG;
    public GameObject SettingPopUp_MainParent;

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
    #endregion

    #region unity function
    public void Start()
    {

        Ref_Animation = Animation.instance;
        Ref_SoundAndMusic = SoundAndMusic.instance;
        Play_BGMusic();
    }
    #endregion

    #region Function
    public void SettingPopUp_Open()
    {
        Ref_Animation.ButtonClickAnimation(Setting_Btn.transform, EndAction: () =>
        {
            SetSound();
            SetMusic();
            SetInputMethod();
            Ref_Animation.PopupAnimation(true, SettingPopUp_MainParent, SettingPopUp_AlphaBG, SettingPopUp_MainBG);
        }
      );
       
    }
    public void SettingPopUP_Close(bool IsAnimation=true)
    {



        Ref_Animation.ButtonClickAnimation(Close_Btn.transform, EndAction: () =>
        {
            if (IsAnimation)
               Ref_Animation.PopupAnimation(false,SettingPopUp_MainParent,SettingPopUp_AlphaBG,SettingPopUp_MainBG);
            else
                SettingPopUp_MainParent.SetActive(false);
        }
       );

    }
  
    public void PlayBtnCLick()
    {
        Ref_Animation.ButtonClickAnimation(Play_Btn.transform, EndAction: () => {
          
            SceneManager.LoadSceneAsync(1);
        }
        );
    }

    public void Touch_On(bool IsAnimation=true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(SingalTouch_ImageSorce.transform, EndAction: () =>
            {
                StaticData.Player_Touch = 0;
                SingalTouch_ImageSorce.sprite = On_Sprite;
                MultiTouch_ImageSorce.sprite = Off_Sprite;
            }
            );
        }
        else
        {
            StaticData.Player_Touch = 0;
            SingalTouch_ImageSorce.sprite = On_Sprite;
            MultiTouch_ImageSorce.sprite = Off_Sprite;
        }

       
    }
    public void Touch_Off(bool IsAnimation = true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(MultiTouch_ImageSorce.transform, EndAction: () =>
            {
                StaticData.Player_Touch = 1;
                SingalTouch_ImageSorce.sprite = Off_Sprite;
                MultiTouch_ImageSorce.sprite = On_Sprite;

            }
           );
        }
        else
        {
            StaticData.Player_Touch = 1;
            SingalTouch_ImageSorce.sprite = Off_Sprite;
            MultiTouch_ImageSorce.sprite = On_Sprite;


        }


    }

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
   
    public void Sound_Slider_Click()
    {
       
        Ref_SoundAndMusic.SetSound_Volume(Sound_Slider.value);
       

    }

    public void Music_Slider_Click()
    {
      
        Ref_SoundAndMusic.SetMusic_Volume(Music_Slider.value);

    }

    public void Sound_on(bool IsAnimation=true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(Sound_ImageSorce.transform, EndAction: () =>
            {

                Ref_SoundAndMusic.SoundMute(false);
                Sound_ImageSorce.sprite = SoundOn_Sprite;
            }
             );
        }
        else
        {
            Ref_SoundAndMusic.SoundMute(false);
            Sound_ImageSorce.sprite = SoundOn_Sprite;
        }


    }
    public void Sound_Off(bool IsAnimation = true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(Sound_ImageSorce.transform, EndAction: () =>
            {

                Ref_SoundAndMusic.SoundMute(true);


                Sound_ImageSorce.sprite = SoundOff_Sprite;
            }
           );
        }
        else
        {
            Ref_SoundAndMusic.SoundMute(true);
            Sound_ImageSorce.sprite = SoundOff_Sprite;

        }
       
    }

    public void Music_on(bool IsAnimation = true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(Music_ImageSorce.transform, EndAction: () =>
            {
                Ref_SoundAndMusic.MuiscMute(false);
                Music_ImageSorce.sprite = MusicOn_Sprite;

            }
           );
        }
        else
        {
            Ref_SoundAndMusic.MuiscMute(false);
            Music_ImageSorce.sprite = MusicOn_Sprite;
        }
        
    }
    public void Music_off(bool IsAnimation = true)
    {
        if (IsAnimation)
        {
            Ref_Animation.ButtonClickAnimation(Music_ImageSorce.transform, EndAction: () =>
            {

                Ref_SoundAndMusic.MuiscMute(true);
                Ref_SoundAndMusic.SetMusic_Volume(0, false);
                Music_ImageSorce.sprite = MusicOff_Sprite;
            }
           );
        }
        else
        {
            Ref_SoundAndMusic.MuiscMute(true);
            Ref_SoundAndMusic.SetMusic_Volume(0, false);
            Music_ImageSorce.sprite = MusicOff_Sprite;
        }

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


    #endregion 
}
