using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAction : MonoBehaviour
{
    public int Index = 0;
    public int TotalButtons = 3;
    public float yOffset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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
                //SceneManager.LoadScene("Prologo");
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
}
