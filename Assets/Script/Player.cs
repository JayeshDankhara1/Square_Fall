using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Varibal
    [Header ("Varibal")]
    public float speed;
    public Vector2 LeftPostion;
    public Vector2 RightPostion;

    [Space]
    [Header("Ref_Scrpit")]
    public GamePlay Ref_GamePlay;

    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ref_GamePlay.Ref_GamePlayUiManager.Play_TouchSound();
            //Ref_GamePlay.Ref_SoundAndMusic.PlayTouch(Ref_GamePlay.Ref_GamePlayUiManager.Click_Clip);
            speed *= -1;
        }     
    }

    private void FixedUpdate()
    {
        PlayerMove();

    }


    public void PlayerMove()
    {
        
        if (transform.position.x >= RightPostion.x || transform.position.x <= LeftPostion.x)
        {
            speed *= -1;
        }
        transform.Translate(speed*Vector3.right*Time.fixedDeltaTime);
        
       
    }
}
