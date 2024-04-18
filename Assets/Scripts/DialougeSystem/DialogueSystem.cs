using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public DialogueBase Dialogue;

    void Start()
    {
        if (Dialogue == null)
        {
            Debug.LogError("Dialogue System not implemented.");
            gameObject.SetActive(false);
        }   
    }

    public void Interacted()
    {
        for (int i = 0; i < Dialogue.dialogue_lines.Length; i++)
        {
            Debug.Log(Dialogue.dialogue_lines[i]);
        }
    }
}
