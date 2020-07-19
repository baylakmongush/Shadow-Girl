using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireFlare : MonoBehaviour
{
    static bool click;
    Animator animator;
    Text    score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        animator = GetComponent<Animator>();
        click = true;
        score = GameObject.FindWithTag("score").GetComponent<Text>();
        score.text = "" + PlayerPrefs.GetInt("score");
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
		if (click)
        {
            animator.SetBool("turn", true);
            Destroy(GameObject.FindGameObjectWithTag("block"));
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
            
            score.text = "" + PlayerPrefs.GetInt("score");
        }
        else
        {
            animator.SetBool("turn", false);
            click = true;
        }
    }
}
