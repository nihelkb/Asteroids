using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public bool isPaused = false;
    public GameObject pauseMenu;

    void Start(){
        pauseMenu.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is called");
        if (Input.GetKeyDown(KeyCode.Escape)) // Tecla ESC
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}
