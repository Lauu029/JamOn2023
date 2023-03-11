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
            Debug.Log("stop");
            stopTimer -= Time.deltaTime;

            if (stopTimer <= 0.0f)
            {
                rb.gravityScale = gravityScale / 2.0f;
                slideTimer = slideTime;
            }

        }

        if (slideTimer > 0.0f) //haciendo slide en la pared
        {
            Debug.Log("slide");
            slideTimer -= Time.deltaTime;

            if (slideTimer <= 0.0f)
                rb.gravityScale = gravityScale;

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        rb.gravityScale = 0.0f;
        stopTimer = stopTime;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exit");
        rb.gravityScale = gravityScale;
    }
}
