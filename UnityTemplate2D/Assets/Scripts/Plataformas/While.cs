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
    void ButtonCheck()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Canon>().shoot(landingPoint, rb, speedThrust, verticalPower);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movimiento>() != null)
        {
            timeWaiting = 0;
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (rb != null)
        {
            timeWaiting += Time.deltaTime;

            if (timeWaiting > timeToJump)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                ButtonCheck();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movimiento>() != null)
        {
            timeWaiting = -1;
            rb = null;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
