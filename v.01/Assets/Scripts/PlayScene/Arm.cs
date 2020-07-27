using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** **/
public struct ArmData
{
    public bool tumblerSave;
}

public class StaticDataArm
{
    public static StaticDataArm Instance { get; } = new StaticDataArm();
    private StaticDataArm()
    {
        armData = new ArmData();//the new is just in case you want to change the struct to a class
        armData.tumblerSave = false;
    }
    public ArmData armData;
}

public class Arm : MonoBehaviour
{
    bool tumbler = false;
    Animator anim;
    float	dist;
	public Transform target;
    void Start()
    {
        anim = GetComponent<Animator>();
        tumbler = StaticDataArm.Instance.armData.tumblerSave;
    }

    private ArmData GetData()
    {
        return new ArmData
        {
            tumblerSave = tumbler
        };
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
        }
        else
            anim.SetBool("open", false);
        StaticDataArm.Instance.armData = GetData();
        if (GameObject.FindWithTag("arm").GetComponent<Arm>().Tumbler == true)
        {
        }
    }
}
