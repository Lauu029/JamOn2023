using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public float velocity;
    public float hold_Aceleration; //Velocidad que se le añade si sigues pulsando el boton
    public float hold_Deceleration; // Cantidad de aceleracion que pierde a medida que sube
    bool jumping;
    Rigidbody2D rb;
    private PlayerController playerActions;
    bool onLand = true;
    //Vector que indica cuanta fuerza lleva
    Vector2 currentForce = new Vector2(0, 0);
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
            currentForce = new Vector2(0, hold_Aceleration);
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Keypad0))
        {
            rb.AddForce(currentForce);

            //Hasta que ya no le quede fuerza
            if (currentForce.y > 0)currentForce = currentForce - new Vector2(0, hold_Deceleration); 
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
