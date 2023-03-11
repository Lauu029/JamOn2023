using UnityEngine;

public class MicLevelDetector : MonoBehaviour
{
    [SerializeField] private float _maxDb = 0;
    [SerializeField] private int _sampleSize = 1024;
    [SerializeField] private string _microphoneName = null;

    private AudioClip _clip;
    private float[] _rawData;

    public float screamingTime; //Tiempo que tiene que estar gritando
    public float screamDb;      //Decibelios que tiene que alcanzar
    public Transform landingPoint;  //Donde aterriza
    public float speedThrust;
    public float verticalPower;

    float timeScreaming = 0.0f; //Tiempo que lleva gritando

    bool interactable = false;
    bool screaming = false;
    Rigidbody2D rb;

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

            if (interactable && Input.GetKeyDown(KeyCode.S)){
                screaming = true;
            }

            if (screaming && timeScreaming < screamingTime)
            {
                _clip.GetData(_rawData, 0);
                float rms = 0;
                 
                for (int i = 0; i < _sampleSize; i++)
                {
                    rms += _rawData[i] * _rawData[i];
                }
                rms = Mathf.Sqrt(rms / _sampleSize);
                float db = 20 * Mathf.Log10(rms);

                if(db >= screamDb)
                {
                    timeScreaming += Time.deltaTime;
                }
            }
            //else if(timeScreaming >= screamingTime && screaming)
            //{
            //    Debug.Log("Te disparo");
            //    //GetComponent<Canon>().shoot(landingPoint, rb, speedThrust, verticalPower);
            //}

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (collision.gameObject.GetComponent<Salto>() != null)
        {
            interactable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Salto>() != null)
        {
            interactable = false;
        }
    }
}