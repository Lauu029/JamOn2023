using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{

    public float verticalVelocity;
    public float horizontalVelocity;
    public float hold_Aceleration; //Velocidad que se le a�ade si sigues pulsando el boton
    public float hold_Deceleration; // Cantidad de aceleracion que pierde a medida que sube
    bool jumping;
    Rigidbody2D rb;
    private PlayerController playerActions;
    bool onLand = true;
    bool onLandSide = false;
    //Vector que indica cuanta fuerza lleva
    Vector2 currentForce = new Vector2(0, 0);
    public bool OnLand { get { return onLand; } }
    public bool OnLandSide { get { return onLandSide; } }
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
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("Jump");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Salto");
        }
    }

    private void FixedUpdate()
    {

        Vector2 jumpVec = new Vector2(0, verticalVelocity);     //Fuerza en vertical
        Vector2 jumpVecSide = new Vector2(horizontalVelocity, 0); //Fuerza en horizontal

        //SI hemos pulsado el boton, y estamos en el suelo o en la pared
        if (jumping && (onLand || onLandSide))
        {
            rb.AddForce(jumpVec); //añadir fuerza vertical
            currentForce = new Vector2(0, hold_Aceleration);

            //Si estamos en la pared, añadimos fuerza horizontal
            if (OnLandSide)
            {
                transform.GetChild(0).GetComponent<Animator>().SetBool("Wall", false);
                if (transform.position.x > 0)
                    rb.AddForce(-jumpVecSide);
                else
                    rb.AddForce(jumpVecSide);

                onLandSide = false;
            }

            onLand = false;
        }

        if (!onLandSide && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Keypad0)))
        {
            rb.AddForce(currentForce);

            //Hasta que ya no le quede fuerza
            if (currentForce.y > 0) currentForce = currentForce - new Vector2(0, hold_Deceleration);
        }

        jumping = false;
    }

    //Metodo al que se llama cuando aterrizas para poder volver a saltar
    public void land()
    {
        onLand = true;
        onLandSide = false;
        GetComponent<Movimiento>().enabled = true;
        transform.GetChild(0).GetComponent<Animator>().SetTrigger("Land");
    }

    public void landSide()
    {
        if (!onLand)
        {
            onLandSide = true;
            GetComponent<Movimiento>().enabled = false;
            transform.GetChild(0).GetComponent<Animator>().SetBool("Wall", true);
        }

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
