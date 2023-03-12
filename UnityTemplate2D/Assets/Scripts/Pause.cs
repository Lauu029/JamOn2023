using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

            if(optionsMenu.activeInHierarchy) 
                EventSystem.current.SetSelectedGameObject(optionsMenu.transform.GetChild(1).gameObject);
            else if(pauseMenu.activeInHierarchy)
                EventSystem.current.SetSelectedGameObject(pauseMenu.transform.GetChild(1).gameObject);
            else
                EventSystem.current.SetSelectedGameObject(null);

            GameManager.instance.togglePause();
        }
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.instance.togglePause();
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenu.transform.GetChild(1).gameObject);
    }

    public void Quit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        GameManager.instance.changeScene("MenuPrincipal");
    }
}
