using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidar : MonoBehaviour
{
    public PrefabsObject Ref_PrefabsObject;
  //  public ObjectSpool Ref_objectSpool;
    public GamePlay Ref_GamePlay;
    public SoundAndMusic Ref_SoundAndMusic;
    public GamePlayUiManager Ref_GamePlayUiManager;

    public void Start()
    {
      //  Ref_objectSpool = ObjectSpool.instance;
        Ref_GamePlay = GamePlay.instance;
        Ref_GamePlayUiManager = GamePlayUiManager.instance;
        Ref_SoundAndMusic = SoundAndMusic.instance;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision== null) return;

        if (collision.CompareTag("Player"))
        {
            
            if (Ref_PrefabsObject.Child.CompareTag("Obstacl"))
            {
                StaticData.Score++;
                Ref_PrefabsObject.Deactive();
                Ref_SoundAndMusic.PlaySound(Ref_GamePlayUiManager.Obstacl_Clip);
            }
            else
            {
                Ref_SoundAndMusic.PlaySound(Ref_GamePlayUiManager.UnObstcl_Clip);
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
