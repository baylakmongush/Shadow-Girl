using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arm : MonoBehaviour
{
    static private bool tumbler = false;
    Animator anim;
    float	dist;
	public Transform target;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public bool Tumbler
    {
        get => tumbler;
        set {
            tumbler = value;
        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
		if(target == null) return;
        Vector3 v = target.position - transform.position;   
        float sqrX = v.x * v.x;     
        float sqrZ = v.z * v.z;     
        float distance = Mathf.Sqrt(sqrX + sqrZ);
        if (distance <= 2)
        {
            anim.SetBool("open", true);
            Tumbler = true;
            GameObject.FindGameObjectWithTag("location").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("location").GetComponent<OpenToPyramid>().sceneEnd = true;
            //GameObject.FindGameObjectWithTag("location").GetComponent<OpenToPyramid>().sceneEnd = false;
            //GameObject.FindGameObjectWithTag("location").GetComponent<Image>().enabled = false;
        }
        else
            anim.SetBool("open", false);
    }
}
