using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireFlare : MonoBehaviour
{
    bool click;
    Animator animator;
    public Transform target;
    //Text    score;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("score", 0);
        animator = GetComponent<Animator>();
        click = true;
        //score = GameObject.FindWithTag("score").GetComponent<Text>();
        //score.text = "" + PlayerPrefs.GetInt("score");
        GameObject.FindGameObjectWithTag("block").GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame

    public bool Click
    {
        get => click;
        set {
            click = value;
        }
    }
    void OnMouseDown()
    {
        if (target == null) return;
        Vector3 v = target.position - transform.position;
        float sqrX = v.x * v.x;
        float sqrZ = v.z * v.z;
        float distance = Mathf.Sqrt(sqrX + sqrZ);
        if (distance <= 2)
        {
            if (click)
            {
                animator.SetBool("turn", true);
                GameObject.FindGameObjectWithTag("block").transform.position =
                new Vector2(GameObject.FindGameObjectWithTag("block").transform.position.x + 8,
                GameObject.FindGameObjectWithTag("block").transform.position.y);
                GameObject.FindGameObjectWithTag("hint").GetComponent<Canvas>().enabled = false;
                GameObject.FindGameObjectWithTag("block").GetComponent<AudioSource>().Play();
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
