using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public ObjectSpool ObjectSpool;

    public void Awake()
    {
        
    }
    public void Start()
    {
        ObjectSpool= ObjectSpool.instance;
       // StartCoroutine(ObstcalSpool());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Obstacl Creat");
         ObjectSpool.ActiveObject();
        }
        

    }

    public IEnumerator ObstcalSpool()
    { 
        yield return new WaitForSeconds(2);
        ObjectSpool.ActiveObject();
    }

}
