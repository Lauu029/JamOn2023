using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter _musicEvent;

    public static GameManager instance;

    bool paused = false;

    int actualLevel = 1;

    float deadTime = -1;

    [SerializeField]
    float timeToReload = 2;

    Transform deathCanvas;

    bool[] unlockedSkins = new bool[50];
    public Sprite[] skins;

    Sprite currentSkin = null;
    int skinIndex = -1;

    int gachaMonedas = 2;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _musicEvent = transform.GetComponent<FMODUnity.StudioEventEmitter>();
        _musicEvent.Play();

        deathCanvas = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (deadTime > -1)
        {
            deadTime += Time.deltaTime;
            if (deadTime >= timeToReload)
                reloadScene();
        }
    }

    public void changeScene(string sc)
    {
        SceneManager.LoadScene(sc);
    }

    public void goToLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
        //_musicEvent.SetParameter("Level", level);
    }

    public void loadNextLevel()
    {
        int next = actualLevel + 1;

        actualLevel = next;
        goToLevel(next);
    }

    public void showWrongAnswer()
    {
        deathCanvas.GetChild(0).gameObject.SetActive(true);
        deadTime = 0;
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        for (int i = 0; i < deathCanvas.childCount; ++i)
            deathCanvas.GetChild(i).gameObject.SetActive(false);
        deadTime = -1;
    }

    public void togglePause()
    {
        paused = !paused;
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void unlockSkins()
    {
        if (gachaMonedas > 0)
        {
            int i = Random.Range(0, skins.Length);
            while (unlockedSkins[i]) i = Random.Range(0, skins.Length);

            unlockedSkins[i] = true;

            for(int j = 0; j < skins.Length; j++)
            {
                Debug.Log(unlockedSkins[j]);
            }
        }
    }

    public void selectSkin(int i)
    {

        for (int j = 0; j < skins.Length; j++)
        {
            Debug.Log(unlockedSkins[j]);
        }

        if (unlockedSkins[i])
        {
            Debug.Log("Cabeza");
            skinIndex = i;
        }
    }

    public Sprite getSkin()
    {
        return skins[skinIndex];
    }
}
