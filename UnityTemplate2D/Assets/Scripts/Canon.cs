using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Vector2 ayuda;

    public void shoot(Transform landingPoint,Rigidbody2D rb ,float speedThrust, float verticalPower)
    {
        Vector2 dir = new Vector2(landingPoint.position.x, landingPoint.position.y) - new Vector2(transform.position.x, transform.position.y);
        dir.Normalize();

        dir.y += verticalPower;   //Me lo estoy inventando literalmente todo
        if(landingPoint.position.x > rb.transform.position.x)dir.x += verticalPower;
        else { dir.x -= verticalPower; }

        //rb.AddForce(dir * speedThrust);

        rb.AddForce(ayuda);

        if(transform.GetChild(1).GetComponent<Animator>() != null)
            transform.GetChild(1).GetComponent<Animator>().SetTrigger("Shoot");

        FMODUnity.RuntimeManager.PlayOneShot("event:/Cañon");
    }
}
