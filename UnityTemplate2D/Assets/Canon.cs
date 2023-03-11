using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public void shoot(Transform landingPoint,Rigidbody2D rb ,float speedThrust, float verticalPower)
    {
        Vector2 dir = new Vector2(landingPoint.position.x, landingPoint.position.y) - new Vector2(transform.position.x, transform.position.y);
        dir.Normalize();

        dir.y += verticalPower;   //Me lo estoy inventando literalmente todo

        rb.AddForce(dir * speedThrust);
    }
}
