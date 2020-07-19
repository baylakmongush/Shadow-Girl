using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool pressed;
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
        if (pressed)
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
            pressed = false;
            audioData.Play();
        }
        else
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
            pressed = true;
            audioData.Stop();
        }
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
            //Get current scene name
        string scene = SceneManager.GetActiveScene().name;
        //Load it
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Cursor.visible = true;
    }

    public void Help()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
    }
    
    public void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
            audioData.Stop();
        }
        if (GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled)
        {
            if(Input.GetKeyDown("escape"))
            {
                GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1f;
            }
        }

    }
}
