using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidar : MonoBehaviour
{
    #region Refrance Script
    public PrefabsObject Ref_PrefabsObject;
    public GamePlay Ref_GamePlay;
    #endregion


    #region Unity Function
    public void Start()
    {  
        Ref_GamePlay = GamePlay.instance;
    }
    #endregion

    #region Function
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision== null) return;

        if (collision.CompareTag("Player"))
        {
            
            if (Ref_PrefabsObject.Child.CompareTag("Obstacl"))
            {
                StaticData.Score++;
                Ref_GamePlay.Ref_GamePlayUiManager.ScoreDispaly(StaticData.Score);
                Ref_PrefabsObject.Deactive();
                Ref_GamePlay.Ref_GamePlayUiManager.Play_Obstacal();
            }
            else
            {
                Ref_GamePlay.Ref_GamePlayUiManager.Play_Unobstacal();
                Ref_GamePlay.GameOver();

             }
        }
        else if (collision.CompareTag("Collidar"))
        {
            Ref_PrefabsObject.Deactive();
        }
    }
    #endregion 
}

