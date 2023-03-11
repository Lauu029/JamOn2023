using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int actualLevel = 1;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(string sc)
    {
        SceneManager.LoadScene(sc);
    }

    public void goToLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);    
    }

    public void loadNextLevel()
    {
        int next = actualLevel + 1;

        actualLevel = next;
        goToLevel(next);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
