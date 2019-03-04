using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMinotauro : MonoBehaviour
{
    float direçãoX;
    [SerializeField]
    private Rigidbody2D Minotaurorb;
    private Animator anim;
    public bool BoneAttack;
    public bool RushAttack;

    Transform player;
    private bool checkTrigger;
    public float speed;
    public Transform target;
    public Transform Edgar;
    // Start is called before the first frame update
    void Start()
    {
        Minotaurorb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(AtaqueOsso());
        BoneAttack = false;
        RushAttack = false;

        Edgar = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    if(RushAttack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            if(Edgar.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            print(transform.position);
        }
    }
    IEnumerator AtaqueOsso()
    {
      yield return new WaitForSeconds(3f);
        BoneAttack = true;
        if(BoneAttack == true)
        {
            GetComponent<Animator>().SetBool("Atk1", true);
        }
        yield return new WaitForSeconds(6f);
        BoneAttack = false;
        if(BoneAttack == false)
        {
            GetComponent<Animator>().SetBool("Atk1", false);
        }
        StartCoroutine(AtaqueCorrendo());
    }
    IEnumerator AtaqueCorrendo()
    {
        yield return new WaitForSeconds(3f);
        RushAttack = true;
            if (RushAttack == true)
        {
            GetComponent<Animator>().SetBool("Atk2", true);
        }
        yield return new WaitForSeconds(6f);
        RushAttack = false;
        if (RushAttack == false)
        {
            GetComponent<Animator>().SetBool("Atk2", false);
        }
        StopCoroutine(AtaqueCorrendo());
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(AtaqueOsso());
    }
    }
