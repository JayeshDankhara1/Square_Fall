using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using DG.Tweening;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PrefabsObject : MonoBehaviour
{

    public bool isActive = false;
    public bool IsFocediraction = false;
    public bool isGameOver = false; 
    public GameObject Child;
    public Rigidbody2D Child_Rigidbody;

    public SpriteRenderer ObstaclSpriteRender;
    public Sprite ObstacalSprite;
    public Sprite UnObsatacalSprite;


    public void Start()
    {
        IsFocediraction= Random.Range(-5,5)<0 ? true : false;
    }

    public void FixedUpdate()
    {
        if (!isActive) return;

         MoveObstacal();
    }

    public void Active()

    {
        transform.position= new Vector3(Random.Range(-1.80f,1.80f),6,0);
        Child.transform.localPosition = new Vector3(0,0,0);
        Child.tag = Random.Range(-5, 10) < 0 ? "Obstacl" : "Unobstacl";
        ObstaclSpriteRender.sprite = Child.CompareTag("Obstacl") ? ObstacalSprite : UnObsatacalSprite;
       // MoveObstacal();
        Child.SetActive(true);
        //Child.tag = "Obstacl";
        isActive = true;
       // Invoke(nameof(Deactive), 10);

    }

    public void Deactive()
    {
        isActive = false;
        Child.SetActive(false);
    }

    public void MoveObstacal()
    {

        if (IsFocediraction)
        { Child_Rigidbody.AddForce(new Vector2(0.5f, 0)); }
        else
        { Child_Rigidbody.AddForce(new Vector2(-0.5f, 0)); }

        //  Child. transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.one);
        //Child.transform.rotation = Quaternion.Euler(Vector3.forward);
        //Child.transform.Rotate(Vector3.one*Time.deltaTime);
    }
}
