using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
 
    const float speedMove = 0.7f;
    AudioSource audio;
    float direction;
    Animator anim;
 
    void Start()
    {
        player = GameObject.FindWithTag("character");
        audio = GetComponent<AudioSource>();
        audio.Stop();
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        direction = player.transform.position.x - transform.position.x;
        if (direction > 0)
            anim.SetBool("direction", false);
        else 
            anim.SetBool("direction", true);
        if (Mathf.Abs(direction) < 5)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }

    }
}
