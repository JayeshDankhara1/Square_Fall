using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidar : MonoBehaviour
{
    public PrefabsObject Ref_PrefabsObject;
  //  public ObjectSpool Ref_objectSpool;
    public GamePlay Ref_GamePlay;
    //public SoundAndMusic Ref_SoundAndMusic;
   // public GamePlayUiManager Ref_GamePlayUiManager;

    public void Start()
    {
      //  Ref_objectSpool = ObjectSpool.instance;
        Ref_GamePlay = GamePlay.instance;
       // Ref_GamePlayUiManager = GamePlayUiManager.instance;
       // Ref_SoundAndMusic = SoundAndMusic.instance;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision== null) return;

        if (collision.CompareTag("Player"))
        {
            
            if (Ref_PrefabsObject.Child.CompareTag("Obstacl"))
            {
                StaticData.Score++;
                //Debug.Log("Score" + StaticData.Score);
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
            
            //collision.gameObject.SetActive(false);


            Ref_PrefabsObject.Deactive();
        }
    }
}
