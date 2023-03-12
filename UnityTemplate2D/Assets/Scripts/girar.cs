using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour
{
    float spinRation = 5.0f;
    float accumulatedRot = 0.0f;
    float totalRot = -1.0f;

    public controlaSkins cS;

    bool spinning = false;
    public void spin()
    {
        spinning = true;

        totalRot = Random.Range(2000.0f, 3000.0f);
    }

    private void Update()
    {
        if(accumulatedRot < totalRot && spinning)
        {
            GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -spinRation));
            accumulatedRot += spinRation;
            spinRation -= 0.005f;
            if (spinRation < 0.2f) spinRation = 0.2f; 
        }

        if (accumulatedRot >= totalRot)
        {
            cS.showSkins();
            spinning = false;
            accumulatedRot = 0;
            spinRation = 5.0f;
        }
        
    }
}
