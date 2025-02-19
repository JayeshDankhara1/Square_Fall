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


    #region Unity Function
    public void Start()
    {
        if (StaticData.Player_Touch == 1)
        {
            Ref_GamePlay.Ref_GamePlayUiManager.MutiTouchButton_On();
        }
        else
        {
            Ref_GamePlay.Ref_GamePlayUiManager.MutiTouchButton_Off();
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && StaticData.Player_Touch == 0)
        {
        
            Ref_GamePlay.Ref_GamePlayUiManager.Play_TouchSound();
            speed *= -1;
        }
       
    }

    private void FixedUpdate()
    {
        PlayerMove();

    }
    #endregion

    #region Function
    public void PlayerMove()
    {
        
        if (transform.position.x >= RightPostion.x || transform.position.x <= LeftPostion.x)
        {
            speed *= -1;
        }
        transform.Translate(speed*Vector3.right*Time.fixedDeltaTime);
        
       
    }
    #endregion
}
