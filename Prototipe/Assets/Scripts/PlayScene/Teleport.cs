using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    static bool tumbler;
    static bool pressed = true;

    static Vector3  position;
    void Start()
    {
    }

    // Update is called once per frame
    public bool Tumbler{
        get => tumbler;
        set {
            tumbler = value;
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
                Destroy(GameObject.FindGameObjectWithTag("teleport_item"));
            if (pressed && Input.GetKeyDown(KeyCode.T))
            {
                GameObject.FindGameObjectWithTag("transition").GetComponent<Image>().enabled = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().sceneEnd = true;
                GameObject.FindGameObjectWithTag("transition").GetComponent<TransitionBetweenLevels>().nextLevel = "Past";
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
    }
}
