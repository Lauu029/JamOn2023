using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public float velocity;
    bool jumping;
    Rigidbody2D rb;
    private PlayerController playerActions;
    bool onLand = true;
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
            jumping = true;
        }
    }

    private void FixedUpdate()
    {

        Vector2 jumpVec = new Vector2(0, velocity);     //Fuerza en vertical

        //SI hemos pulsado el boton, y estamos en el suelo
        if (jumping && onLand)
        {
            rb.AddForce(jumpVec);
            onLand = false;
        }

        jumping = false;
    }

    //Metodo al que se llama cuando aterrizas para poder volver a saltar
    public void land()
    {
        onLand = true;
    }

    private void OnEnable()
    {
        playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerActions.Player.Disable();
    }
}
