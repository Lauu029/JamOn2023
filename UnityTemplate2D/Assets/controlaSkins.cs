using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaSkins : MonoBehaviour
{
    public GameObject[] buttons;

    private void Awake()
    {
        showSkins();
    }

    public void showSkins()
    {
        bool[] s = GameManager.instance.getunlockSkins();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (s[i]) buttons[i].SetActive(true);
        }
    }
}
