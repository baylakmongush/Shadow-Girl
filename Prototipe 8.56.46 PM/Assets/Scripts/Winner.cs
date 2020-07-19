using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Stop();
    }

    // Update is called once per frame
    void Accelerate()
    {
        SceneManager.LoadScene("Winner", LoadSceneMode.Single);
    }
    void OnMouseDown()
 	{
        audio.Play();
        InvokeRepeating("Accelerate", 0, 3);
    }
}
