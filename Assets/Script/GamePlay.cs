using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{

    #region Script Refance
    public static GamePlay instance;
    public ObjectSpool Ref_ObjectSpool;
    public Player Ref_Player;
    public SoundAndMusic Ref_SoundAndMusic;
    public GamePlayUiManager Ref_GamePlayUiManager;
    public GamePlayButtonManager Ref_GamePlayButtonManager;
    public GoogleAds Ref_GoogleAds;
    #endregion

    #region Varibal
    public bool IsGameOver = false;
    #endregion

    #region Unity Function
    public void Awake()
    {
            instance = this;
    }

    public void Start()
    {
       
        Ref_GamePlayUiManager = GamePlayUiManager.instance;
        Ref_GamePlayButtonManager = GamePlayButtonManager.instance;
        Ref_ObjectSpool = ObjectSpool.instance;
        Ref_SoundAndMusic = SoundAndMusic.instance;
        Ref_GoogleAds = GoogleAds.instance;
        Ref_GamePlayUiManager.GameOverPopUp_Close(false);
        StartCoroutine(TimeCoundowan());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
         Ref_ObjectSpool.ActiveObject();
        }
    }

    #endregion

    #region Function
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

    public IEnumerator TimeCoundowan()
    {
        
        for (int i = 3; i >= 0; i--)
        {
            Ref_GamePlayUiManager.CounDowan_Set(true);
            if (i > 0)
            { Ref_GamePlayUiManager.CounDowan(i.ToString()); }
            else
            { Ref_GamePlayUiManager.CounDowan("Go.!!!"); }
            yield return new WaitForSeconds(1);
        }
        Ref_GamePlayUiManager.CounDowan_Set(false);
        GameStart();
    }
    #endregion

}
