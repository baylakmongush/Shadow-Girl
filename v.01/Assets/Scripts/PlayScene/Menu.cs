using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool pressed_help;
    AudioSource audioData;
    void Start()
    {
        audioData = GameObject.FindWithTag("MenuButton").GetComponent<AudioSource>();
        audioData.Stop();
        Cursor.visible = true;
    }
    public void ClickButton()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
        audioData.Play();
    }

    public void ReturnGame()
    { 
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        audioData.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        ResetData resetData = new ResetData();
        resetData.ResetD();
        SceneManager.LoadScene("Present", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void Help()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("menu_button").GetComponent<Button>().enabled = false;
        Time.timeScale = 0f;
    }
    
    public void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
            audioData.Stop();
            GameObject.FindWithTag("menu_button").GetComponent<Button>().enabled = true;
        }
        if (GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled)
        {
            if(Input.GetKeyDown("escape"))
            {
                GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1f;
                GameObject.FindWithTag("menu_button").GetComponent<Button>().enabled = true;
            }
        }

    }
}
