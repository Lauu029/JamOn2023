using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class If_Platform : MonoBehaviour
{
    public float speedThrust; //Velocidad que se le añade si acierta
    public float verticalPower; //Fuerza adicional en vertical par mandarlo mas para arriba que de lado

    bool interactable = false;

    string[] preguntas = { "¿Es Guille bajito?", "¿A que le huelen los sobacos a Carlos Leon?", "Los dedos de la mano, los dedos de los pies, lo cojones y la polla todos suman...",
        "¿El pimiento es una fruta?", "¿A que huelen los pingüinos", "¿Te comerias un culo por 50 millones de euros", "¿Cual es la mejor asociación del mundo?" };
    respuestas[] resp = new respuestas[50];


    string[] buenas = { "Si", "A paro", "23", "Si", "Calla friki", "Depende del culo", "Diskobolo" };
    string[] malas = { "No", "A trabajo", "Ese tipo de humor no tiene cabida en esta jam", "No", "A pescado", "Si", "La ETA" };

    int buenarda = -1;

    Rigidbody2D rb;
    GameObject canvas;
    public Transform landingPoint; //Punto al que envias al jugador
    struct respuestas
    {
        public string buena;
        public string mala;
    }

    private void Awake()
    {

        for (int i = 0; i < preguntas.Length; i++)
        {
            resp[i].buena = buenas[i];
            resp[i].mala = malas[i];
        }

        canvas = transform.GetChild(0).gameObject;
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
            canvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.S))
        {
            showQuestion();
        }

        /*if(Input.GetKeyDown(KeyCode.Q) && buenarda == 0)
        {
            GetComponent<Canon>().shoot(landingPoint, rb,speedThrust, verticalPower);
        }
        else if(Input.GetKeyDown(KeyCode.E) && buenarda == 1)
        {
            GetComponent<Canon>().shoot(landingPoint, rb,speedThrust, verticalPower);
        }*/
    }

    private void showQuestion()
    {
        Debug.Log(resp.Length);
        int question = Random.Range(0, preguntas.Length);
        canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = preguntas[question];
        Debug.Log(preguntas[question]);

        int buena = Random.Range(0, 2);
        buenarda = buena;

        if (buena == 0)
        {
            Debug.Log(resp[question].buena);
            canvas.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = resp[question].buena;
            Debug.Log(resp[question].mala);
            canvas.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = resp[question].mala;
        }
        else
        {
            Debug.Log(resp[question].mala);
            canvas.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = resp[question].mala;
            Debug.Log(resp[question].buena);
            canvas.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = resp[question].buena;
        }

        canvas.SetActive(true);
    }

    public void checkAnswer(int answer)
    {
        if (answer == buenarda)
            GetComponent<Canon>().shoot(landingPoint, rb, speedThrust, verticalPower);
        else
            GameManager.instance.reloadScene();
    }
}
