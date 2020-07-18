using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** TO SAVE CHARACTER POSITION **/
public struct PlayerData
 {
     public Vector3 position;
     public Quaternion rotation;
 }
 
public class StaticData
{
     public static StaticData Instance {get;} = new StaticData();
     private StaticData()
     {
         playerData = new PlayerData();//the new is just in case you want to change the struct to a class
         playerData.position = Vector3.zero;
         playerData.rotation = Quaternion.identity;            
     }    
     public PlayerData playerData;
}
/**     **/

public class CharacterManager : MonoBehaviour
{
    float speed = 2f;
    Rigidbody2D rigidbody;
    public float    jumpForce = 0.7f;
    public bool isGrounded;
    Animator anim;

    public BoxCollider2D    collider2D;
    void Start()
    {
        transform.position = StaticData.Instance.playerData.position;
        transform.rotation = StaticData.Instance.playerData.rotation;
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
 	{
     	if (col.gameObject.tag == ("Ground") && isGrounded == false)
     	{
         	isGrounded = true;
     	}
 	}
    private PlayerData GetData()
    {
         return new PlayerData
         {
             position = transform.position,
             rotation = transform.rotation
         };
     }

    void FixedUpdate()
    {
        Vector3 temp = GameObject.FindWithTag("teleport").GetComponent<Teleport>().Position(transform.position);
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0)
            anim.SetBool("walk_left", true);
        else
            anim.SetBool("walk_left", false);
        if (horizontal < 0)
            anim.SetBool("walk_right", true);
        else
            anim.SetBool("walk_right", false);
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //anim.SetBool("walk_right", true);
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        transform.position = temp;
        StaticData.Instance.playerData = GetData();
    }
}
