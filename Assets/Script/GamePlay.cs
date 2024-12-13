using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public ObjectSpool ObjectSpool;
    public bool IsGameOver = false;
    public static GamePlay instance;
    public Player Ref_Player;

   


    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ObjectSpool = ObjectSpool.instance;
        GameStart();
       // StartCoroutine(ObstcalSpool());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
           // Debug.Log("Obstacl Creat");
         ObjectSpool.ActiveObject();
        }
        

    }

   

    public IEnumerator ObstcalSpool()
    {
        while (!IsGameOver)
        {
            yield return new WaitForSeconds(1f);
            ObjectSpool.ActiveObject();
        }
    }


    public void GameOver()
    { 
        IsGameOver = true;
        StopAllCoroutines();
        ObjectSpool.AllObjectsDeactive();
        Ref_Player.speed = 0f;

    }

    public void GameStart()
    {
        Ref_Player.speed =-1f;
        IsGameOver = false;
        StartCoroutine(ObstcalSpool());
    }

}
