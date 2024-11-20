using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PrefabsObject : MonoBehaviour
{

    public bool isActive = false;


    public void IsActive(bool isActive=false)
    { 
        transform.gameObject.SetActive(isActive);
        this.isActive = isActive;
        if (this.isActive)
        {
            Invoke(nameof(IsActive), 10);
        }

    }
}
