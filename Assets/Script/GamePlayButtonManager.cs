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
                
                break;
            case "Reload":
                Click_Reload();
                break ;
            

        }
    }

    


    public void Sound_Click()
    { 
        if(StaticData.MuteSound==0)
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
        
    }

   

}
