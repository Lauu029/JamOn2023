using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearSkin : MonoBehaviour
{
    public GameObject cabeza;

    private void Awake()
    {
        cabeza.GetComponent<SpriteRenderer>().sprite = GameManager.instance.getSkin();
    }
}
