using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearSkin : MonoBehaviour
{
    public GameObject cabeza;

    private void Awake()
    {
        Debug.Log("ME pongo el sombrero");
        cabeza.GetComponent<SpriteRenderer>().sprite = GameManager.instance.getSkin();
    }
}
