using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Transform Gone;
    public GameObject Text;
    public Animator Porta;
    public bool ItsGone;
    public bool Walk;
    // Start is called before the first frame update
    void Start()
    {
        Walk = false;
        ItsGone = false;
    }

    // Update is called once per frame
    void Update()
    {
        SoldierGone();
    }
   public void SoldierGone()
    {
        if (Walk == true)
        {
            transform.eulerAngles = new Vector2(0, 180);
            transform.position = Vector2.MoveTowards(transform.position, Gone.position, 5 * Time.deltaTime);
            if (transform.position.x > Gone.transform.position.x)
            {
                transform.gameObject.SetActive(false);
                ItsGone = true;
            }
        }
        if (ItsGone == true)
        {
            Porta.SetBool("Abre", false);
        } 
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Porta")
        {
            Porta.SetBool("Abre", true);
        }
    }
}
