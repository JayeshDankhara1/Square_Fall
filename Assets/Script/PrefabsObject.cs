using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PrefabsObject : MonoBehaviour
{

    public bool isActive = false;
    public GameObject Child;


    public void Active()
    { 
        transform.position= new Vector3(Random.Range(-1.80f,1.80f),6,0);  
        Child.SetActive(true);
        isActive = true;
       // Invoke(nameof(Deactive), 10);

    }

    public void Deactive()
    {
        Child.SetActive(false);
        isActive = false;
    }
}
