using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transiçao : MonoBehaviour
{
    public Image Panel;
    public Image liones;
    public bool coolingDown;
    public float waitTime = 30.0f;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Leao();
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            Panel.fillAmount += 10.0f / waitTime * Time.deltaTime;
        }

        if (Panel.fillAmount >= 1)
        {
            StartCoroutine(LoadScene());
        }
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Porta")
        {
           //Aviso.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            if (Input.GetKeyDown(KeyCode.X))
            {
                coolingDown = true;
            }
        }
    }
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(LevelName);
    }
    public IEnumerator Lion()
    {
        yield return new WaitForSeconds(0.5f);
        liones.fillAmount -= 30.0f / waitTime * Time.deltaTime;

    }
    void Leao()
    {
        if (Panel.fillAmount == 0)
        {
            StartCoroutine(Lion());
        }
    }
}

    
