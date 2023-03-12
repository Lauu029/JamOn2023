using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Victoria");
        if (collision.gameObject.GetComponent<Movimiento>() != null)
            GameManager.instance.changeScene("EscenaIntermedia");
    }
}
