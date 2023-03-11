using UnityEngine;

public class MicLevelDetector : MonoBehaviour
{
    [SerializeField] private float _maxDb = 0;
    [SerializeField] private int _sampleSize = 1024;
    [SerializeField] private string _microphoneName = null;

    private AudioClip _clip;
    private float[] _rawData;

    private void Start()
    {
        if (_microphoneName == null)
        {
            _microphoneName = Microphone.devices[0];
        }

        _clip = Microphone.Start(_microphoneName, true, 1, AudioSettings.outputSampleRate);
        _rawData = new float[_sampleSize];
    }

    private void Update()
    {
        if (Microphone.IsRecording(_microphoneName))
        {
            _clip.GetData(_rawData, 0);
            float rms = 0;
            for (int i = 0; i < _sampleSize; i++)
            {
                rms += _rawData[i] * _rawData[i];
            }
            rms = Mathf.Sqrt(rms / _sampleSize);
            float db = 20 * Mathf.Log10(rms);
            if (db > _maxDb)
            {
                _maxDb = db;
            }
        }
    }

    public float GetMaxDb()
    {
        float result = _maxDb;
        _maxDb = 0;
        return result;
    }

    private void OnDisable()
    {
        Microphone.End(_microphoneName);
    }
}