using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comentario : MonoBehaviour
{
    float timer = -1;

    [SerializeField]
    float timeToDisappear;

    [SerializeField]
    float timeToBlink;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer >= 0)
        {
            timer += Time.deltaTime;
            if (timer >= timeToDisappear)
                GameObject.Destroy(gameObject);
            else if (timer >= timeToBlink)
                GetComponent<Blinker>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.position.y > transform.position.y)
            timer = 0;
    }
}
