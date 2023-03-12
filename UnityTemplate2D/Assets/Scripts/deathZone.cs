using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public float ascendingVelocity; //Velocidad a la que sube la deathZone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Salto>())
        {
            GameManager.instance.reloadScene();
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, ascendingVelocity, 0));
    }
}
