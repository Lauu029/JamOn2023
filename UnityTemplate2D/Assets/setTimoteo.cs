using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTimoteo : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.setTimer(this.gameObject);
    }
}
