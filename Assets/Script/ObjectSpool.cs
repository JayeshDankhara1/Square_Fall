using System.Collections;
using System.Collections.Generic;
using DG.Tweening.CustomPlugins;
using UnityEngine;

public class ObjectSpool : MonoBehaviour
{
    #region Varibal & Refrance Script
    public List<PrefabsObject> objects = new List<PrefabsObject> ();
    public PrefabsObject prefab;
    public Transform prefabParent;

    public GamePlay Ref_GamePlay;
    public static ObjectSpool instance;
    #endregion 
    #region Unity function
    public void Awake()
    {
        instance = this;
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    void Start()
    {
        Ref_GamePlay = GamePlay.instance;
        InstanatiteCreate(25);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    #endregion

    #region Other Function

    public void InstanatiteCreate(int temp)
    {
        for (int i = 0; i < temp; i++)
        {
            objects.Add(Instantiate(prefab, prefabParent));
            objects[i].Deactive();
        }
    }
    public void ActiveObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (!objects[i].isActive)
            {
                objects[i].Active();
                
                return;
            }
        }

       // Debug.Log("New One created");
        InstanatiteCreate(1);
        objects[objects.Count - 1].Active();
    }

    public void AllObjectsDeactive()
    {

        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].Deactive();
        }
       
    }
    #endregion
}
