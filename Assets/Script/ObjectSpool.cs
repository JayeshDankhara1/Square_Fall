using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpool : MonoBehaviour
{

    public List<PrefabsObject> objects = new List<PrefabsObject> ();
    public PrefabsObject prefab;
    public Transform prefabParent;


    void Start()
    {
        InstanatiteCreate(25);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) 
       {
            ActiveObject();
       }

    }

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
        InstanatiteCreate(1);
        objects[objects.Count - 1].Active();
    }
}
