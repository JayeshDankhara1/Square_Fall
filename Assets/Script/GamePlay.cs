using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public ObjectSpool Ref_ObjectSpool;
    public bool IsGameOver = false;
    public static GamePlay instance;
    public Player Ref_Player;
    
    public SoundAndMusic Ref_SoundAndMusic;
    public GamePlayUiManager Ref_GamePlayUiManager;
    public GamePlayButtonManager Ref_GamePlayButtonManager;
  //  public SettingPopUp Ref_SettingPopUp;


    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        Ref_GamePlayUiManager.GameOverPopUp_Close();
        Ref_ObjectSpool = ObjectSpool.instance;
        Ref_SoundAndMusic = SoundAndMusic.instance;
        
        
        GameStart();
       // StartCoroutine(ObstcalSpool());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

           // Debug.Log("Obstacl Creat");
         Ref_ObjectSpool.ActiveObject();

        }
        

    }

   

    public IEnumerator ObstcalSpool()
    {
        while (!IsGameOver)
        {
            yield return new WaitForSeconds(Random.Range(0.2f,1.5f));
            Ref_ObjectSpool.ActiveObject();
           
        }
    }


    public void GameOver()
    { 
      
        Game_Pause();
        Ref_GamePlayButtonManager.GameOverPopUp_Load();


    }

    public void GameStart()
    {
        StaticData.Score = 0;
        Game_Play();
    }

    public void Game_Pause()
    {
        IsGameOver = true;
        StopAllCoroutines();
        Ref_ObjectSpool.AllObjectsDeactive();
        Ref_Player.speed = 0f;
    }

    public void Game_Play()
    {
        Ref_Player.speed = -2f;
        IsGameOver = false;
        StartCoroutine(ObstcalSpool());
    }
}
