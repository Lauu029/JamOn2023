using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public float velocity;
    bool jumping;
    Rigidbody2D rb;
    private PlayerController playerActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActions = new PlayerController();
        //playerActions = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detectamos el input
        if (playerActions.Player.Jump.triggered)
        {
            Debug.Log("Hola");
            jumping = true;

        }
    }

    private void FixedUpdate()
    {
        Vector2 jumpVec = playerActions.Player.Move.ReadValue<Vector2>(); //La dirección del salto en horizontal

        jumpVec = jumpVec * velocity; //Multiplicamos por la fuerza que queramos

        if (!jumping)
        {
            rb.AddForce(-jumpVec);
            Debug.Log("Salto");
        }
    }
}
