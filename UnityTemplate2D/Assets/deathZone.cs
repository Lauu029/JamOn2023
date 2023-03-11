using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public Transform respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Salto>())
        {
            collision.GetComponent<Transform>().position = respawn.position;
        }
    }
}
