using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    [SerializeField]
    int direction = 1;

    [SerializeField]
    float strength = 5;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(direction * strength, 0));
    }
}
