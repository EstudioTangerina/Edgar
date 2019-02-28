using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMinotauro : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Minotaurorb;
    private Animator anim;
    public bool BoneAttack;
    public bool RushAttack;
    // Start is called before the first frame update
    void Start()
    {
        Minotaurorb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(AtaqueOsso());
        BoneAttack = false;
        RushAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
    
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
        if(RushAttack == true)
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
