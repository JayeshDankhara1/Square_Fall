using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class PrefabsObject : MonoBehaviour
{

    public bool isActive = false;
    public GameObject Child;
    public Rigidbody2D Child_Rigidbody;

  
    public void Update()
    {
        MoveObstacal();
    }

    public void Active()
    { 
        transform.position= new Vector3(Random.Range(-1.80f,1.80f),6,0);
       // MoveObstacal();
        Child.SetActive(true);
        Child.tag = "Obstacl";
        isActive = true;
       // Invoke(nameof(Deactive), 10);

    }

    public void Deactive()
    {
        Child.SetActive(false);
        isActive = false;
    }

    public void MoveObstacal()
    {
      //  Child_Rigidbody.AddForce(new Vector2(Random.Range(-1f,1f),0));
        Child_Rigidbody.AddForce(new Vector2(0.1f,0));
     //   Debug.Log("Obstacal Move");
        //Child_Rigidbody.DOMoveX(transform.position.x  *0.2F * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      
            Debug.Log(collision.gameObject);


    }

}
