using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool pressed;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        Cursor.visible = true;
    }

    public void Help()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = true;
        if(Input.GetKeyDown("escape"))
        {
            GameObject.FindWithTag("Help").GetComponent<Canvas>().enabled = false;
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = true;
        }
    }
    
    public void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
            audioData.Stop();
        }

    }
}
