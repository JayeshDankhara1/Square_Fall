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
        Child.SetActive(true);
        isActive = true;
        Invoke(nameof(Deactive), 10);

    }

    public void Deactive()
    {
        Child.SetActive(false);
        isActive = false;
    }
}
