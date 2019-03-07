using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transiçao : MonoBehaviour
{
    public int Index;
    public string LevelName;


    public Image white;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator LoadScene()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => white.color.a == 1);
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            StartCoroutine(LoadScene());
        }
    }
}

    
