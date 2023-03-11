using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public Transform respawn;           //Punto donde vuelve a aparecer el jugador una vez muere
    public Transform deathZoneInitZone; //Punto a donde vuelve la deathZone cuando el jugador muere

    public float ascendingVelocity; //Velocidad a la que sube la deathZone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Salto>())
        {
            collision.GetComponent<Transform>().position = respawn.position;
            transform.position = deathZoneInitZone.position;
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, ascendingVelocity, 0));
    }
}
