using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Base", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogueBase : ScriptableObject
{
    public string[] dialogue_lines;

    public Dictionary<int, string> dialogue_options;
    
}
