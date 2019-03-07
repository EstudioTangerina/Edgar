using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEdgar : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    //public Animator PortaAnim;
    public GameObject Aviso;
    //public Image white;
    //public GameObject Panel;
    //public Animator Fadeanim;

    private float speed;
    private float horizontalspeed;
    public float jumpSpeed = 5.5f;
    public string LevelName;

    private int timeJump;
    int Index;

    bool Foi;
    bool andar;
    private bool isGrounded = true;
    public bool Dormindo;
    public bool Andando;
    bool AvisoUtilizado;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 4.5f;
        Dormindo = false;
        Andando = false;
        AvisoUtilizado = false;
        Foi = false;
        Index = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (AvisoUtilizado == true)
        {
            Aviso.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }


    }
    void FixedUpdate()
    {
        Walk();
        Jump();
        Ataques();
        LeIndex();
        if (isGrounded == false) anim.SetBool("Pulo", true);
        else anim.SetBool("Pulo", false);
        anim.SetFloat("Blend", rb.velocity.y);
    }
    void Walk()
    {
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        anim.SetLayerWeight(2, 0);
        anim.SetLayerWeight(1, 1);
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
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && timeJump < 2 || Input.GetKeyDown(KeyCode.W) && timeJump < 2)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            timeJump++;
            isGrounded = false;
        }
    }
    void LeIndex()
    {
        if (Foi == true)
        {
            if (Index < 0)
            {
                Andando = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            timeJump = 0;
            isGrounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
      
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
    }
}
