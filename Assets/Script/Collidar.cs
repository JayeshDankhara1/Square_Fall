using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidar : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision== null) return;

        if (collision.CompareTag("Obstacl"))
        {
            collision.gameObject.SetActive(false);

        }

    }
}
