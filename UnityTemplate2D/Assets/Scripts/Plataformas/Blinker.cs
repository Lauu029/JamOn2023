using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    float timeSinceLastBlink = 0;

    [SerializeField]
    float timeBetweenBlinks;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBlink += Time.deltaTime;
        if(timeSinceLastBlink > timeBetweenBlinks)
        {
            timeSinceLastBlink = 0;
            sprite.enabled = !sprite.enabled;
        }
    }
}
