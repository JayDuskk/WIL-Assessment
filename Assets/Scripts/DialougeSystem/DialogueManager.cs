using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Player;

    [Header("UI Objects")]
    public GameObject MainCanvas;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI Option1Text;
    public TextMeshProUGUI Option2Text;
    

    Dictionary<string, DialogueOptions[]> dialogues = new Dictionary<string, DialogueOptions[]>();
    DialogueOptions[] options;

    public void SetDictionary(Dictionary<string, DialogueOptions[]> dictionary)
    {
        dialogues = dictionary;
    }

    public void setDialogue(string dialogue, DialogueOptions[] dialogueOptions)
    {
        MainCanvas.SetActive(true);
        options = dialogueOptions;
        DialogueText.text = dialogue;
        Option1Text.text = dialogueOptions[0].response_option;
        Option2Text.text = dialogueOptions[1].response_option;
        
    }


    public void button1Clicked()
    {
        int nextLine = options[0].guide;
        if (nextLine > 0) 
        {

            setDialogue(dialogues.ElementAt(nextLine).Key, dialogues.ElementAt(nextLine).Value);
        }
        if(nextLine == -1)
        {
            Player.GetComponent<FirstPersonController>().MoveSpeed = 4;
            Player.GetComponent<FirstPersonController>().RotationSpeed = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MainCanvas.SetActive(false);
        }
    }

    public void button2Clicked()
    {
        int nextLine = options[1].guide;
        if(nextLine > 0)
        {
            setDialogue(dialogues.ElementAt(nextLine).Key, dialogues.ElementAt(nextLine).Value);
        }
        if (nextLine == -1)
        {
            Player.GetComponent<FirstPersonController>().MoveSpeed = 4;
            Player.GetComponent<FirstPersonController>().RotationSpeed = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MainCanvas.SetActive(false);
        }
    }
}
