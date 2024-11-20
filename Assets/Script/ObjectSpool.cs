using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpool : MonoBehaviour
{

    public List<PrefabsObject> objects = new List<PrefabsObject> ();
    public GameObject prefab;
    public Transform prefabParent;


    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
          objects.Add(Instantiate(prefab.GetComponent<PrefabsObject>(), prefabParent));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {

            for (int i = 0; i < 25; i++)
            {
                if (!objects[i].isActive)
                { 
                    objects[i].IsActive(true);
                    break;
                }
            }

        }

    }
}
