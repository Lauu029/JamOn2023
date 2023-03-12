using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pies : MonoBehaviour
{
    Salto s;

    private void Awake()
    {
        s = GetComponentInParent<Salto>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WallCollision>() == null)
            s.land();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.GetComponent<WallCollision>() == null)
            s.fall();
    }
}
