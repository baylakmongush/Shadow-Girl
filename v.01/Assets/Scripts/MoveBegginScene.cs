using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBegginScene : MonoBehaviour
{
    // Update is called once per frame
    UnityEngine.Video.VideoPlayer vp;
    private void Start()
    {
        vp = GetComponent<UnityEngine.Video.VideoPlayer>();
        vp.Play();
        vp.loopPointReached += CheckOver;
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Beginning", LoadSceneMode.Single);
    }
}
