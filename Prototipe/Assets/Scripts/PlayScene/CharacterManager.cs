using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** TO SAVE CHARACTER POSITION **/
public struct PlayerData
 {
     public Vector3 position;
     public Quaternion rotation;
     public int     health;
 }
 
public class StaticData
{
     public static StaticData Instance {get;} = new StaticData();
     private StaticData()
     {
        playerData = new PlayerData();//the new is just in case you want to change the struct to a class
        playerData.position = Vector3.zero;
        playerData.rotation = Quaternion.identity;
        playerData.health = 3;
     }    
     public PlayerData playerData;
}
/**     **/

public class CharacterManager : MonoBehaviour
{
    public Image[] hearts;
    float speed = 2f;
    Rigidbody2D rigidbody;
    public float    jumpForce = 0.7f;
    public bool isGrounded;
    Animator anim;
    private int _health;

    public BoxCollider2D    collider2D;
    void Start()
    {
        transform.position = StaticData.Instance.playerData.position;
        transform.rotation = StaticData.Instance.playerData.rotation;
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        _health = StaticData.Instance.playerData.health;
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
 	{
         int i = 3;

     	if (col.gameObject.tag == ("Ground") && isGrounded == false)
     	{
         	isGrounded = true;
     	}
         Debug.Log(_health);
        if (col.gameObject.tag == ("Enemy") && _health > 0)
     	{
         	_health--;
             hearts[_health].enabled = false;
     	}
        if (_health == 0)
            Debug.Log("GAME OVER");

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
