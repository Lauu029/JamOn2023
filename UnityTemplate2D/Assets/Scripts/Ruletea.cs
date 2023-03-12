using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruletea : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.unlockSkins();
    }
}
