using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionEdgar : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Animator PortaAnim;
    public GameObject Aviso;
    public Image white;
    public GameObject Panel;
    public Animator Fadeanim;

    private float speed;
    private float horizontalspeed;
    public float jumpSpeed = 5.5f;
    public string LevelName;

    private int timeJump;
    int Index;

    public bool Foi;
    bool andar;
    private bool isGrounded = true;
    public bool Dormiu;
    public bool Andando;
    bool AvisoUtilizado;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 4.5f;
        Dormiu = true;
        Andando = false;
        AvisoUtilizado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Index == 0)
        {
            anim.SetBool("Dormindo", Dormiu);

            if (Dormiu == true)
            {
                anim.SetLayerWeight(2, 1);
                anim.SetLayerWeight(1, 0);
            }
        }
        if (Andando == true)
        {
            Dormiu = false;
            Index = 1;
            anim.SetLayerWeight(2, 0);
            anim.SetLayerWeight(1, 1);
        }   
    }
    void FixedUpdate()
    {  
        if(Andando == true)
        {
            Walk();
            Jump();
        }
        Ataques();
        if (isGrounded == false) anim.SetBool("Pulo", true);
        else anim.SetBool("Pulo", false);
        anim.SetFloat("Blend", rb.velocity.y);
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
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Chao")
        {
            Dormiu = false;
            Andando = true;
            timeJump = 0;
            isGrounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Porta")
        {
            Aviso.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            if (Input.GetKeyDown(KeyCode.X))
            {
                PortaAnim.SetBool("Abre", true);
                AvisoUtilizado = true;
                Panel.SetActive(true);
                //StartCoroutine(LoadScene());
                Andando = true;
            }
        }
    }
    /*public IEnumerator LoadScene()
    {
        Fadeanim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
        SceneManager.LoadScene(LevelName);
    }*/
  
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Porta")
        {
            Aviso.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }
    
        
        
}
