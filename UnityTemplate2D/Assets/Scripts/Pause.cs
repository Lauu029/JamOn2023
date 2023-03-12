using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject optionsMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
            optionsMenu.SetActive(false);
            GameManager.instance.togglePause();
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        GameManager.instance.togglePause();
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        GameManager.instance.changeScene("MenuPrincipal");
    }
}
