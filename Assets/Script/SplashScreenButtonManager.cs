
using UnityEngine;


public class SplashScreenButtonManager : MonoBehaviour
{

    #region Refrance Script
    public SplashScreenUiManagar Ref_SplashScreenUiManagar;
    #endregion

    #region Unity Function
    public void Start()
    {
        Ref_SplashScreenUiManagar.SettingPopUP_Close(false);
     
    }
    #endregion

    #region Function
    public void ButtonManager(string BtnName)
    {
  
        Ref_SplashScreenUiManagar.Play_TouchSound();

        switch (BtnName)
        {
            case "Play":
                Play_Click();
                break;
            case "Open_SettingPopUp":
                SettingPopUp_Click();
                break;
            case "Close_SettingPopUp":
                SettingPopUp_Close();
                break;
            case "Sound_Click":
                Sound_Click();
                break;
            case "Music_Click":
                Music_Click();
                break;
            case "Sound_Slidar":
                SoundSlidar_Click();
                break;
            case "Music_Slidar":
                MusicSlidar_Click();
                break;
            case "Singal_Touch":
                SingalTouch_Click();
                break;
            case "Multi_Touch":
                MultiTouch_Click();
                break;
        }
    }

    public void Play_Click()
    {
            Ref_SplashScreenUiManagar.PlayBtnCLick();
        
    }
    public void Sound_Click()
    {
        if (StaticData.MuteSound == 0)
        {
            Ref_SplashScreenUiManagar.Sound_Off();
           
        }
        else
        {
            Ref_SplashScreenUiManagar.Sound_on();
            
        }
    }

    public void Music_Click()
    {
        if (StaticData.MuteMusic == 0)
        {
            Ref_SplashScreenUiManagar.Music_off();
       
        }
        else
        {
            Ref_SplashScreenUiManagar.Music_on();
            
        }
    }

    public void SoundSlidar_Click()
    {
        Ref_SplashScreenUiManagar.Sound_Slider_Click();
    }

    public void MusicSlidar_Click()
    {
        Ref_SplashScreenUiManagar.Music_Slider_Click();
    }


   
    public void SettingPopUp_Click()
    {

        Ref_SplashScreenUiManagar.SettingPopUp_Open();
    }

    public void SettingPopUp_Close()
    {
        Ref_SplashScreenUiManagar.SettingPopUP_Close();
       
    }

    public void SingalTouch_Click()
    {
        Ref_SplashScreenUiManagar.Touch_On();
    }

    public void MultiTouch_Click()
    {
        Ref_SplashScreenUiManagar.Touch_Off();
    }

    #endregion


}
