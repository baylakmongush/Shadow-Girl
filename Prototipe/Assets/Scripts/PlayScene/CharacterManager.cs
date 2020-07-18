using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** TO SAVE CHARACTER POSITION **/
public struct PlayerData
 {
     public Vector3 position;
     public Quaternion rotation;

     public int damage;
 }
 
public class StaticData
{
     public static StaticData Instance {get;} = new StaticData();
     private StaticData()
     {
        playerData = new PlayerData();//the new is just in case you want to change the struct to a class
        playerData.position = Vector3.zero;
        playerData.rotation = Quaternion.identity;
        playerData.damage = 3;
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
    int _health;
    public Image[] hearts;

    AudioSource audio;


    void EnabledHearts()
    {
        if (_health == 3)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = true;
            hearts[2].enabled = true;

        }
        if (_health == 2)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = true;
            hearts[2].enabled = false;
            hearts[2].GetComponent<AudioSource>().Play();
            audio.Play();
        }
        if (_health == 1)
        {
            hearts[0].enabled = true;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
            hearts[1].GetComponent<AudioSource>().Play();
            audio.Play();
        }
        if (_health == 0)
        {
            hearts[0].enabled = false;
            hearts[1].enabled = false;
            hearts[2].enabled = false;
            GameObject.FindWithTag("GameOver").GetComponent<AudioSource>().Play();
            Debug.Log("FINISH");
        }
    }
    void Start()
    {
        _health = StaticData.Instance.playerData.damage;
        EnabledHearts();
        transform.position = StaticData.Instance.playerData.position;
        transform.rotation = StaticData.Instance.playerData.rotation;
        rigidbody = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        Debug.Log(StaticData.Instance.playerData.damage);
        for(int i = 0; i < 3; i++)
             hearts[i].GetComponent<AudioSource>().Stop();
        audio = GetComponent<AudioSource>();
        audio.Stop();
        GameObject.FindWithTag("GameOver").GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
 	{
     	if (col.gameObject.tag == ("Ground") && isGrounded == false)
         	isGrounded = true;

        if (col.gameObject.tag == ("Enemy"))
            Hurt();

 	}
    private PlayerData GetData()
    {
         return new PlayerData
         {
            position = transform.position,
            rotation = transform.rotation,
            damage = _health,
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
    void Hurt()
    {
        if (_health >= 0 && _health <= 3)
        {
            if (_health != 0)
                _health--;
            EnabledHearts();
            Debug.Log(_health);
        }
    }
}
