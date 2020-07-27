using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


/** **/
public struct Bug
{
    public bool tumblerSave;
    public bool pressedSave;
}

public class StaticDataBug
{
    public static StaticDataBug Instance { get; } = new StaticDataBug();
    private StaticDataBug()
    {
        bugData = new Bug();//the new is just in case you want to change the struct to a class
        bugData.tumblerSave = false;
        bugData.pressedSave = true;
    }
    public Bug bugData;
}
/**     **/

public class Teleport : MonoBehaviour
{
    bool tumbler = false;
    bool pressed = true;
    AudioSource audio;

    private void Start()
    {
        tumbler = StaticDataBug.Instance.bugData.tumblerSave;
        pressed = StaticDataBug.Instance.bugData.pressedSave;
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    private Bug GetData()
    {
        return new Bug
        {
            tumblerSave = tumbler,
            pressedSave = pressed
        };
    }

    // Update is called once per frame
    public bool Tumbler{
        get => tumbler;
        set {
            tumbler = value;
        }
    }

    public bool Pressed
    {
        get => pressed;
        set
        {
            pressed = value;
        }
    }

    public Vector3 Position(Vector3 v){
        return (v);
    }
    void Update()
    {
        if (tumbler)
        {
            if (GameObject.FindGameObjectWithTag("teleport_item") != null)
            {
                if (GameObject.FindGameObjectWithTag("hint") != null)
                    GameObject.FindGameObjectWithTag("hint").GetComponent<Canvas>().enabled = false;
                Destroy(GameObject.FindGameObjectWithTag("teleport_item"));
            }
            GameObject.FindGameObjectWithTag("Skarabei").GetComponent<Image>().enabled = true;
            if (pressed && Input.GetKeyDown(KeyCode.T))
            {
                GameObject.FindGameObjectWithTag("transition").GetComponent<Image>().enabled = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().sceneEnd = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().nextLevel = "Past";
                audio.Play();
                pressed = false;
            }
            else if (!pressed && Input.GetKeyDown(KeyCode.T))
            {
                GameObject.FindGameObjectWithTag("transition").GetComponent<Image>().enabled = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().sceneEnd = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().nextLevel = "Present";
                pressed = true;
            }
        }
        else
            GameObject.FindGameObjectWithTag("Skarabei").GetComponent<Image>().enabled = false;
        StaticDataBug.Instance.bugData = GetData();
    }
}
