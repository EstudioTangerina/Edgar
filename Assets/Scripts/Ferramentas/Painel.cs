using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painel : MonoBehaviour
{
    public GameObject Soldier;
    public GameObject Panel;
    public bool QAA;
    // Start is called before the first frame update
    void Start()
    {
       Soldier = GameObject.FindGameObjectWithTag("Soldier");
       Panel = GameObject.FindGameObjectWithTag("Speak");
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Panel.)
        {
            print("Aeeee");
        }*/
    }
}
