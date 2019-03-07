using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.1f;
    public float CharacterRateMultiplier = 0.1f;

    public KeyCode DialogueInput = KeyCode.Mouse0;

    private bool _isDialoguePlaying = false;

    public bool EleAcordou = false;

    public GameObject EdgarUp;
    public GameObject Texto;
    public Animator anim;
    // Use this for initialization
    void Start()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";
        EdgarUp = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDialoguePlaying)
        {
            _isDialoguePlaying = true;
            StartCoroutine(StartDialogue());
        }
        //EdgarAcorda();
        if(EleAcordou == true)
        {
            Texto.SetActive(false);
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
        EleAcordou = true;
        EdgarUp.gameObject.GetComponent<EdgarSleep>().Andando = true;
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
}
