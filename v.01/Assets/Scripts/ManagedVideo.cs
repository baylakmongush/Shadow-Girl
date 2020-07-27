using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagedVideo : MonoBehaviour
{
    void Start()
    {
    	GameObject.FindWithTag("Main").GetComponent<Canvas>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
    	var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
        if (vp.isPlaying)
            GameObject.FindWithTag("Main").GetComponent<Canvas>().enabled = false;
        else
            GameObject.FindWithTag("Main").GetComponent<Canvas>().enabled = true;
        if (Input.GetKeyDown("escape") && vp.isPlaying)
            vp.enabled = false;
    }
}
