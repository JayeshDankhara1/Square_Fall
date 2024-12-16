using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayButtonManager : MonoBehaviour
{
 //   public Button Button;
   public GamePlay Ref_GamePlay;

    public void Start()
    {
      // Button.transform.DOPunchScale(Vector3.one*1.2f,1); 
    }
    public void Button_Click(string button)
    {
        
        switch(button)
        {

            case "Close_SettingPopUp":
                SettingPopUp_Close();
                break;
            case "Open_SettingPopUp":
                SettingPopUp_Click();
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
            case "Reload":
                RePlay_Game();
                break;
            case "Left_ButtonClick":
                Left_ButtonClick();
                break;
            case "Right_ButtonClick":
                Right_ButtonClick();
                break;
        }
    }

    
    public void Sound_Click()
    {
        if (StaticData.MuteSound == 0)
        {
            Ref_GamePlay.Ref_GamePlayUiManager.Sound_Off();
           // Ref_GamePlay.Ref_GamePlayUiManager.SetSound(0f);
        }
        else
        {
            Ref_GamePlay.Ref_GamePlayUiManager.Sound_on();
            //Ref_GamePlay.Ref_GamePlayUiManager.SetSound(StaticData.Sound);
        }
    }

    public void Music_Click()
    {
        if (StaticData.MuteMusic == 0)
        {
            Ref_GamePlay.Ref_GamePlayUiManager.Music_off();
           // Ref_GamePlay.Ref_GamePlayUiManager.SetMusic(0f);
        }
        else
        {
            Ref_GamePlay.Ref_GamePlayUiManager.Music_on();
            //Ref_GamePlay.Ref_GamePlayUiManager.SetMusic(StaticData.Music);
        }
    }

    public void SoundSlidar_Click()
    { 
        Ref_GamePlay.Ref_GamePlayUiManager.Sound_Slider_Click();
    }

    public void MusicSlidar_Click()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.Music_Slider_Click();
    }


    public void Click_Reload()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Close();
        Ref_GamePlay.GameStart();

    }

    public void GameOverPopUp_Load()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Open();
     
    }

    public void SettingPopUp_Click()
    {
        Ref_GamePlay.Game_Pause();
        Ref_GamePlay.Ref_GamePlayUiManager.SettingPopUp_Open();
    }

    public void SettingPopUp_Close()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.SettingPopUp_Close();
        Ref_GamePlay.Game_Play();
    }

    public void RePlay_Game()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Close();
        Ref_GamePlay.GameStart();
    }

    public void Left_ButtonClick()
    {
        Ref_GamePlay.Ref_Player.speed = -2;
    }
    public void Right_ButtonClick()
    {
        Ref_GamePlay.Ref_Player.speed = 2;
    }
}
