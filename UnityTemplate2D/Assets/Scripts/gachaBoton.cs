using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gachaBoton : MonoBehaviour
{
    public void select(int i)
    {
        GameManager.instance.selectSkin(i);
    }
}
