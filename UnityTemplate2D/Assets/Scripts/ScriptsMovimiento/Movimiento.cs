using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController;
    private Animator playerAnim;
    private SpriteRenderer spriteRnd;

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

        playerAnim = transform.GetChild(0).GetComponent<Animator>();
        spriteRnd = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVal = playerController.Player.Move.ReadValue<Vector2>();
        bool decel = true;
        if (moveVal.x != 0)
        {
            float y = rb.velocity.y;
            velocity = Mathf.Min(velocity + velocityFactor * Time.deltaTime, maxVelocity);
            Vector2 input = new Vector2(moveVal.x, 0).normalized * velocity;

            input.y = y;
            rb.velocity = input;
            decel = false;
        }
        else if(rb.velocity.x > 0.01f || rb.velocity.x < -0.01f)
        {
            float sign = rb.velocity.x / Mathf.Abs(rb.velocity.x);
            float newVel = Mathf.Max(Mathf.Abs(rb.velocity.x) - deceleration * Time.deltaTime, 0);
            rb.velocity = new Vector2(newVel * sign, rb.velocity.y);
            velocity = initialVelocity;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        playerAnim.SetFloat("Velocity", Mathf.Abs(rb.velocity.x));
        if (rb.velocity.x != 0.0f)
            playerAnim.speed = Mathf.Abs(rb.velocity.x) / maxVelocity;
        else
            playerAnim.speed = 1;
        Debug.Log(playerAnim.speed);

        if(!decel)
            _ = rb.velocity.x < 0.0f ? spriteRnd.flipX = true : spriteRnd.flipX = false;
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
