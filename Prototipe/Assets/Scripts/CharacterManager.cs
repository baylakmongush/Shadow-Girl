using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    float speed = 2f;
    Rigidbody2D rigidbody;
    public float    jumpForce = 0.7f;
    public bool isGrounded;

    public BoxCollider2D    collider2D;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
 	{
     	if (col.gameObject.tag == ("Ground") && isGrounded == false)
     	{
         	isGrounded = true;
     	}
 	}
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
