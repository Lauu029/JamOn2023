using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class monedaActu : MonoBehaviour
{
    private void Awake()
    {
        actualiza();
    }

    public void actualiza()
    {
        GetComponent<TextMeshProUGUI>().text = GameManager.instance.getCoins().ToString();
    }
}
