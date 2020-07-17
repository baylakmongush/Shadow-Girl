using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool pressed;
    AudioSource audioData;
    void Start()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        audioData = GetComponent<AudioSource>();
        audioData.Stop();
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
        GameObject.FindWithTag("menu_button").GetComponent<AudioSource>().Stop();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Help()
    {
        
    }
}
