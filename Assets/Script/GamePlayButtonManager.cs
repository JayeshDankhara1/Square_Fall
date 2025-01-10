using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayButtonManager : MonoBehaviour
{
    #region Refance Script
    public GamePlay Ref_GamePlay;
    public static GamePlayButtonManager instance;
    #endregion


    #region Unity Function
    public void Awake()
    {
        instance = this;
    }
    #endregion

    #region Other Function

    public void Button_Click(string button)
    {
        Ref_GamePlay.Ref_GamePlayUiManager.Play_TouchSound();
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
            case "Home":
                Home_Click();
                break;
        }
    }
 

    #endregion

    #region SettingPopUP Function
    public void Sound_Click()
    {


        if (StaticData.MuteSound == 0) 
             Ref_GamePlay.Ref_GamePlayUiManager.Sound_Off(); 
        else 
            Ref_GamePlay.Ref_GamePlayUiManager.Sound_on();
  
    }

    public void Music_Click()
    {
        if (StaticData.MuteMusic == 0)
            Ref_GamePlay.Ref_GamePlayUiManager.Music_off();
        else
            Ref_GamePlay.Ref_GamePlayUiManager.Music_on();
    }

    public void SoundSlidar_Click()
    { 
        Ref_GamePlay.Ref_GamePlayUiManager.Sound_Slider_Click();
    }

    public void MusicSlidar_Click()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.Music_Slider_Click();
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

    #endregion

    #region GameOverPop Function
    
    public void GameOverPopUp_Load()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Open();

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
    public void Home_Click() => Ref_GamePlay.Ref_GamePlayUiManager.HomeBtnCLick();
    #endregion

}



