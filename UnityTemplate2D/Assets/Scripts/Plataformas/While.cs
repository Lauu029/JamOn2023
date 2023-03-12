using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class While : MonoBehaviour
{
    float timeWaiting = -1;

    [SerializeField]
    float timeToJump = 3;

    [SerializeField]
    Transform landingPoint;

    [SerializeField]
    float verticalPower;

    [SerializeField]
    float speedThrust;

    Rigidbody2D rb;
    private PlayerController playerActions;

    [SerializeField]
    int pressesNeeded = 15;

    int presses = 0;
    private void Awake()
    {
        playerActions = new PlayerController();
    }

    void ButtonCheck()
    {
        if (Input.GetButtonUp("Fire3")||Input.GetKeyUp(KeyCode.E))
        {
            presses++;
            transform.GetChild(0).GetComponent<Animation>().Play();
            Debug.Log(presses);
            if (presses >= pressesNeeded)
                GetComponent<Canon>().shoot(landingPoint, rb, speedThrust, verticalPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movimiento>() != null)
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (rb != null)
        {
            ButtonCheck();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movimiento>() != null)
        {
            presses = 0;
            rb = null;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
