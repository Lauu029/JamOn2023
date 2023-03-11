using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    Rigidbody2D rb;


    [SerializeField]
    float stopTime = 1.0f, slideTime = 1.0f;
    float stopTimer = 0.0f, slideTimer = 0.0f;
    float gravityScale;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    private void Update()
    {
        if (stopTimer > 0.0f) //parado en la pared
        {
            stopTimer -= Time.deltaTime;

            if (stopTimer <= 0.0f)
            {
                rb.gravityScale = gravityScale / 5.0f;
                slideTimer = slideTime;
            }

        }

        if (slideTimer > 0.0f) //haciendo slide en la pared
        {
            slideTimer -= Time.deltaTime;

            if (slideTimer <= 0.0f)
                rb.gravityScale = gravityScale;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = 0.0f;
        rb.velocity = Vector2.zero;
        stopTimer = stopTime;

        if (!player.GetComponent<Salto>().OnLand)
            player.GetComponent<Movimiento>().enabled = false;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb.gravityScale = gravityScale;

        player.GetComponent<Movimiento>().enabled = true;
    }
}
