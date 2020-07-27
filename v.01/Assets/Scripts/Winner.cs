using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audio;
    public Transform target;
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
        if (target == null) return;
        Vector3 v = target.position - transform.position;
        float sqrX = v.x * v.x;
        float sqrZ = v.z * v.z;
        float distance = Mathf.Sqrt(sqrX + sqrZ);
        if (distance <= 1)
        {
            audio.Play();
            InvokeRepeating("Accelerate", 0, 3);
        }
    }
}
