using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MicLevelDetector : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    [SerializeField] private float _maxDb = 0;

    private void Update()
    {
        
        float db = 0.0f; 
        _emitter.EventInstance.getVolume(out db);

        if (db > _maxDb)
        {
            _maxDb = db;
            Debug.Log("Que llegaron lo aparato");
        }
    }

    public float GetMaxDb()
    {
        float result = _maxDb;
        _maxDb = 0;
        return result;
    }
}