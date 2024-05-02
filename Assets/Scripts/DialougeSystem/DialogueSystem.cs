using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public DialogueBase Dialogue;
    public GameObject DialogueManager;
    public GameObject Player;
   

    DialogueManager manager;
    void Start()
    {
        if (Dialogue == null)
        {
            Debug.LogError("Dialogue System not implemented.");
            gameObject.SetActive(false);
        }   

        manager = DialogueManager.GetComponent<DialogueManager>();
    }

    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(transform.position - Player.transform.position, Vector3.up);
        rotation.x = 0.0f;
        rotation.z = 0.0f;
        transform.rotation = rotation;
    }

    public void Interacted()
    {

        Player.GetComponent<FirstPersonController>().MoveSpeed = 0;
        Player.GetComponent<FirstPersonController>().RotationSpeed = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;


        string[] lines = Dialogue.getLines();
        DialogueOptions[] options = Dialogue.getOptions();
        List<DialogueOptions> tOptions = new List<DialogueOptions>();
        Dictionary<string, DialogueOptions[]> dialogues = new Dictionary<string, DialogueOptions[]>();

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < options.Length; j++)
            {
                print("Index : " + i +"\nFound Index : " + options[j].line_id);
               if (options[j].line_id == i)
                {
                    DialogueOptions tOp = options[j];
                    print("Added: " + tOp);
                    tOptions.Add(tOp);
                    
                }
            }
            dialogues.Add(lines[i], tOptions.ToArray());
            print(tOptions.Count);
            tOptions.Clear();
            print("refresh");
        }
        
        int index = 0;

        manager.SetDictionary(dialogues);
        manager.setDialogue(dialogues.ElementAt(index).Key, dialogues.ElementAt(index).Value);
      

        
    }
}
