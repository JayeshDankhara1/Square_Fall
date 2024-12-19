using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation: MonoBehaviour
{
  public bool IsClick = false;


    public static Animation instance;



    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
      //  Debug.Log(IsClick);
    }
}
