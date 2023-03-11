using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

    [SerializeField]
    GameObject player;
    Rigidbody2D rb;
    Salto salto;
    Movimiento movimiento;



    [SerializeField]
    float stopTime = 1.0f, slideTime = 1.0f;
    float stopTimer = -1.0f, slideTimer = -1.0f;
    float gravityScale;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
        salto = player.GetComponent<Salto>();
        movimiento = player.GetComponent<Movimiento>();
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

        salto.landSide();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rb.gravityScale = gravityScale;

        stopTimer = -1.0f;
        slideTimer = -1.0f;

        movimiento.enabled = true;
    }

}
