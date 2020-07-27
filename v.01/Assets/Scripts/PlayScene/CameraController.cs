using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float trackSpeed = 10000f;
    static Vector3 v;
     // Set target
    public void SetTarget(Transform t) {
         target = t;
    }

    // Track target
    void LateUpdate() {
        if (target) {
            v = transform.position;
            v.x = target.position.x;
            if (GameObject.FindGameObjectWithTag("character").transform.position.x > 1f ||
                GameObject.FindGameObjectWithTag("character").transform.position.x > 36f)
            {
                if (GameObject.FindWithTag("wall1") != null)
                {
                    if (GameObject.FindGameObjectWithTag("character").transform.position.x > 24)
                        GameObject.FindWithTag("teleport").GetComponent<Teleport>().Tumbler = false;
                    if (GameObject.FindWithTag("arm").GetComponent<Arm>().Tumbler == false && GameObject.FindGameObjectWithTag("character").transform.position.x < GameObject.FindGameObjectWithTag("wall1").transform.position.x)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
                    }
                }
                transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
            }
        }
    }
}
