using StarterAssets;
using System;
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
    public UnityEngine.UI.Image spriteImage;
    

    Dictionary<DialogueLine, DialogueOptions[]> dialogues = new Dictionary<DialogueLine, DialogueOptions[]>();
    DialogueOptions[] options;
    AnimationFrames[] animFrames;
    public float delay = 0.25f;

    public void SetDictionary(Dictionary<DialogueLine, DialogueOptions[]> dictionary)
    {
        dialogues = dictionary;
    }

    IEnumerator animate(int spriteID, AnimationFrames[] frames)
    {

        if (spriteID >= 0)
        {
            spriteImage.gameObject.SetActive(true);
            
            spriteImage.sprite = frames[spriteID].frames[0];
            spriteImage.SetNativeSize();
            yield return new WaitForSeconds(delay);
            spriteImage.sprite = frames[spriteID].frames[1];
            yield return new WaitForSeconds(delay);
            spriteImage.sprite = frames[spriteID].frames[2]; ;
            yield return new WaitForSeconds(delay);
            spriteImage.sprite = frames[spriteID].frames[0];
            yield return null;
        }
        else
        {
            spriteImage.gameObject.SetActive(false);
        }
    }

    public void setDialogue(DialogueLine dialogue, DialogueOptions[] dialogueOptions, AnimationFrames[] animationFrames)
    {
        animFrames = animationFrames;
        MainCanvas.SetActive(true);
        options = dialogueOptions;
        DialogueText.text = dialogue.dialogueLine;
        StartCoroutine(animate(dialogue.spriteID,animFrames));
        if (dialogueOptions.Length > 0)
        {
            Option1Text.text = dialogueOptions[0].response_option;
            Option2Text.text = dialogueOptions[1].response_option;
        }
        else
        {
            Debug.Log("No Options Provided");

            DialogueOptions dl1 = new DialogueOptions();
            DialogueOptions dl2 = new DialogueOptions();
            int index = dialogues.Keys.ToList().IndexOf(dialogue);
            print(dialogues.Count);
            if (index == dialogues.Count - 1)
            {
                dl1.response_option = "Exit";
                dl2.response_option = "Exit";
                dl1.guide = -1;
                dl2.guide = -1;
            }
            else
            {
                dl1.response_option = "Continue";
                dl2.response_option = "Continue";
                dl1.guide = index + 1;
                dl2.guide = index + 1;
            }
            if(dialogues.TryGetValue(dialogue, out DialogueOptions[] dlo))
            {
                DialogueOptions[] newDialogueOptions = new DialogueOptions[] { dl1, dl2 };
                dialogues[dialogue] = newDialogueOptions;

                setDialogue(dialogue, newDialogueOptions, animationFrames);
            }
        }
    }


    public void button1Clicked()
    {
        int nextLine = options[0].guide;
        if (nextLine > 0) 
        {

            setDialogue(dialogues.ElementAt(nextLine).Key, dialogues.ElementAt(nextLine).Value, animFrames);
        }
        if(nextLine == -1)
        {
            Player.GetComponent<FirstPersonController>().MoveSpeed = 4;
            Player.GetComponent<FirstPersonController>().RotationSpeed = 1;
            Player.GetComponent<InteractionSystem>().reEnable();
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
            setDialogue(dialogues.ElementAt(nextLine).Key, dialogues.ElementAt(nextLine).Value, animFrames);
        }
        if (nextLine == -1)
        {
            Player.GetComponent<FirstPersonController>().MoveSpeed = 4;
            Player.GetComponent<FirstPersonController>().RotationSpeed = 1;
            Player.GetComponent<InteractionSystem>().reEnable();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            MainCanvas.SetActive(false);
        }
    }
}
