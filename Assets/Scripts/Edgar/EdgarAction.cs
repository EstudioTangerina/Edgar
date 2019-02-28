using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgarAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private float horizontalspeed;
    private Animator anim;
    bool andar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        Walk();
        Ataques();
    }
    void Walk()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.eulerAngles = new Vector2(0, 0);
        }


        /*if (Input.GetKeyDown(KeyCode.UpArrow) && timeJump < 2 || Input.GetKeyDown(KeyCode.W) && timeJump < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            timeJump++;
            isGrounded = false;
        }*/

    }
    void Ataques()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("Ataque", true);
        }
        else
        {
            anim.SetBool("Ataque", false);
        }
    }
}
