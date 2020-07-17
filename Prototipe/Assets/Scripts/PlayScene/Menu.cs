using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool pressed;
    void Start()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
    }
    public void ClickButton()
    {
        if (pressed)
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
            pressed = false;
        }
        else
        {
            GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1f;
            pressed = true;
        }
    }

    public void ReturnGame()
    {
        GameObject.FindWithTag("Menu").GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Help()
    {
        
    }
}
