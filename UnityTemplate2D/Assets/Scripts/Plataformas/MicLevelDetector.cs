using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MicLevelDetector : MonoBehaviour
{
    [SerializeField] private float _maxDb = 0;
    [SerializeField] private int _sampleSize = 1024;
    [SerializeField] private string _microphoneName = "";

    private AudioClip _clip;
    private float[] _rawData;

    public float screamingTime; //Tiempo que tiene que estar gritando
    public float screamDb = 0f;      //Decibelios que tiene que alcanzar
    public Transform landingPoint;  //Donde aterriza
    public float speedThrust;
    public float verticalPower;

    float timeScreaming = 0.0f; //Tiempo que lleva gritando

    bool interactable = false;
    bool screaming = false;
    Rigidbody2D rb;

    [SerializeField] private Slider leftTimeBar;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject text;

    string[] phrases = { "Grita 'Cleon pirata somalí' hasta que se acabe el tiempo",
                         "Grita 'Guille ...' hasta que se acabe el tiempo"};

    private void Start()
    {
        if (_microphoneName == "")
        {
            _microphoneName = Microphone.devices[0];
        }

        _clip = Microphone.Start(_microphoneName, true, 1, AudioSettings.outputSampleRate);
        _rawData = new float[_sampleSize];
    }

    private void Update()
    {

        if (interactable && Input.GetKeyDown(KeyCode.S))
        {
            screaming = true;
            text.GetComponent<TextMeshProUGUI>().text = phrases[Random.Range(0, phrases.Length)];
            canvas.SetActive(true);
        }

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


            if (screamDb < db)
            {
                if (screaming && timeScreaming < screamingTime)
                {
                    timeScreaming += Time.deltaTime;
                    leftTimeBar.value = (1.0f - timeScreaming / screamingTime);
                }
            }
        }
        if (timeScreaming >= screamingTime && screaming)
        {
            GetComponent<Canon>().shoot(landingPoint, rb, speedThrust, verticalPower);
            canvas.SetActive(false);
            this.enabled = false;
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