using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlare : MonoBehaviour
{
    static bool click;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        click = true;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if (click)
        {
            animator.SetBool("turn", true);
            click = false;
        }
        else
        {
            animator.SetBool("turn", false);
            click = true;
        }
    }
}
