using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialSoldier : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.1f;
    public float CharacterRateMultiplier = 0.1f;

    public KeyCode DialogueInput = KeyCode.Mouse0;

    public bool _isDialoguePlaying = false;

    public GameObject Soldier;

    // Use this for initialization
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        Soldier = GameObject.FindGameObjectWithTag("Soldier");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDialoguePlaying)
        {
            _isDialoguePlaying = true;
            StartCoroutine(StartDialogue());
        }

    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength)
        {
            yield return StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex]));
            currentDialogueIndex++;
        }
        //Add as coisas
        transform.parent.gameObject.SetActive(false);
        SoldierGone();
        _isDialoguePlaying = false;
    }
    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;
            if (currentCharacterIndex < stringLength)
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
            else
            {
                break;
            }
        }
        while (true)
        {
            if (Input.GetKeyDown(DialogueInput))
            {
                break;
            }
            yield return 0;
        }
        _textComponent.text = "";
    }
    void SoldierGone()
    {
        if(transform.parent.gameObject.activeInHierarchy == false)
        {
            Soldier.gameObject.GetComponent<Soldier>().Walk = true;
        }
    }
}
