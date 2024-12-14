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
            case "Close_GameOver":
                Click_CloseBtn();
                break;
            case "Close_SettingPopUp":
                
                break;
            case "Reload":
                Click_Reload();
                break ;
            

        }
    }

    public void Click_CloseBtn()
    {
       
    }

    public void Click_Reload()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Close();
        Ref_GamePlay.GameStart();

    }

    public void GameOverPopUp_Load()
    {
        Ref_GamePlay.Ref_GamePlayUiManager.GameOverPopUp_Open();
        Ref_GamePlay.Ref_GamePlayUiManager.ScoreText.text=(StaticData.Score).ToString();
    }

   

}
