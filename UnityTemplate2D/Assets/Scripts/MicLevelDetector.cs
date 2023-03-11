using UnityEngine;
using FMODUnity;

public class MicLevelDetector : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    [SerializeField] private float _maxDb = 0;

    private void Update()
    {
        float db = 20.0f * Mathf.Log10(_emitter.EventInstance.getRMSAmplitude());
        if (db > _maxDb) _maxDb = db;
    }

    public float GetMaxDb()
    {
        float result = _maxDb;
        _maxDb = 0;
        return result;
    }
}