using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{


    public Animator animator;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            IdleAnim();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateAnim   ();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScaleAnim();
        }
    }


    public void ScaleAnim()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Rotate", false);
        animator.SetBool("Scale", true);
    }
    public void RotateAnim()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Rotate", true);
        animator.SetBool("Scale", false);
    } 
    public void IdleAnim()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Rotate", false);
        animator.SetBool("Scale", false);
    }


}
