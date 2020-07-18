using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBug : MonoBehaviour
{
	float	dist;
	public Transform target;
	SpriteRenderer sprite;

	void Start() {
		sprite = GetComponent<SpriteRenderer>();	
	}
    void OnMouseDown()
    {
		if(target == null) return;
        Vector3 v = target.position - transform.position;   
        float sqrX = v.x * v.x;     
        float sqrZ = v.z * v.z;     
        float distance = Mathf.Sqrt(sqrX + sqrZ);
        if (distance <= 1)
		{
			sprite.color = new Color (1, 0, 0, 1);
			GameObject.FindWithTag("teleport").GetComponent<Teleport>().Tumbler = true;
		}
    }

}
