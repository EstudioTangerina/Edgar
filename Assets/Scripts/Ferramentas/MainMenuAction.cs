using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuAction : MonoBehaviour
{
    public int Index = 0;
    public int TotalButtons = 3;
    public float yOffset = 1f;

    public Image Panel;
    public bool coolingDown;
    public float waitTime = 30.0f;


    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        coolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            Panel.fillAmount += 10.0f / waitTime * Time.deltaTime;
        }

        if (Panel.fillAmount >= 1)
        {
            StartCoroutine(LoadScene());
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if(Index < TotalButtons - 1)
            {
                Index++;
                Vector2 position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (Index > 0)
            {
                Index--;
                Vector2 position = transform.position;
                position.y += yOffset;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Index == 0)
            {             
                coolingDown = true;
                print("Prologo");
            }
            else if (Index == 1)
            {
                //SceneManager.LoadScene("Options");
                print("Options");
            }
            else if (Index == 2)
            {
                //Application.Quit();
                print("Exit");
            }
        }
    }
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.5f);
        if (Index == 0)
        {
            
                SceneManager.LoadScene("Prólogo");
                //print("Vai q é tua");
            
           
        }
    }

}


