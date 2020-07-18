using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
 
    const float speedMove = 0.7f;
 
    void Start()
    {
        player = GameObject.FindWithTag("character");
    }
 
    void Update()
    {
        float direction = player.transform.position.x - transform.position.x;
 
        if (Mathf.Abs(direction) < 5)
        {
            Vector3 pos = transform.position;
            pos.x += Mathf.Sign(direction) * speedMove * Time.deltaTime;
            transform.position = pos;
        }
    }
}
