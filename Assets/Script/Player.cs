using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Vector2 LeftPostion;
    public Vector2 RightPostion;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed *= -1;
        }     
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= RightPostion.x || transform.position.x <= LeftPostion.x)
        {
            //
            //
            //Debug.Log("Condton Test");
            speed *= -1;
        }
        transform.Translate(speed*Vector3.right*Time.fixedDeltaTime);
    }


    public void PlayerMove()
    {

        
       
    }
}
