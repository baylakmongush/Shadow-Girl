using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float trackSpeed = 7f;
     // Set target
    public void SetTarget(Transform t) {
         target = t;
     }

     // Track target
     void LateUpdate() {
         if (target) {
             var v = transform.position;
             v.x = target.position.x;
            if (GameObject.FindGameObjectWithTag("character").transform.position.x >= -13 &&
            GameObject.FindGameObjectWithTag("character").transform.position.x <= 30 &&
            GameObject.FindGameObjectWithTag("character").transform.position.x > GameObject.FindGameObjectWithTag("wall").transform.position.x)
            {
                if (GameObject.FindGameObjectWithTag("character") != null)
                {
                    if (GameObject.FindWithTag("arm").GetComponent<Arm>().Tumbler == false && GameObject.FindGameObjectWithTag("character").transform.position.x < GameObject.FindGameObjectWithTag("wall1").transform.position.x)
                    {
                            transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
                    }
                }
            }
            if (GameObject.FindGameObjectWithTag("character").transform.position.x > GameObject.FindGameObjectWithTag("wall2").transform.position.x)
            {
                if (GameObject.FindWithTag("arm").GetComponent<Arm>().Tumbler == true)
                {
                    GameObject.FindGameObjectWithTag("wall4").transform.position = new Vector2(30, GameObject.FindGameObjectWithTag("wall4").transform.position.y);
                    Destroy(GameObject.FindGameObjectWithTag("wall1")); // стена - препятствие
                    transform.position = Vector3.MoveTowards(transform.position, v, trackSpeed * Time.deltaTime);
                }
            }
         }
     }
}
