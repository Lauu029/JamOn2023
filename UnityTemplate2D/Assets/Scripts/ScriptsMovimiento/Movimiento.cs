using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController;

    private float velocity;

    [SerializeField]
    float initialVelocity;

    [SerializeField]
    float maxVelocity;

    [SerializeField]
    float velocityFactor;

    [SerializeField]
    float deceleration;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = new PlayerController();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVal = playerController.Player.Move.ReadValue<Vector2>();
        if (moveVal.x != 0)
        {
            float y = rb.velocity.y;
            velocity = Mathf.Min(velocity + velocityFactor * Time.deltaTime, maxVelocity);
            Vector2 input = new Vector2(moveVal.x, 0).normalized * velocity;

            input.y = y;
            rb.velocity = input;
        }
        else if(rb.velocity.x != 0)
        {
            float sign = rb.velocity.x / Mathf.Abs(rb.velocity.x);
            float newVel = Mathf.Max(Mathf.Abs(rb.velocity.x) - deceleration * Time.deltaTime, 0);
            rb.velocity = new Vector2(newVel * sign, rb.velocity.y);
            Debug.Log(rb.velocity);
            velocity = /*Mathf.Max(velocity - velocityFactor * Time.deltaTime,*/ initialVelocity;
        }
    }

    private void OnEnable()
    {
        playerController.Player.Enable();
    }

    private void OnDisable()
    {
        playerController.Player.Disable();
    }
}
