using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using AYellowpaper.SerializedCollections;
using Unity.VisualScripting;


[System.Serializable]
public struct DialogueOptions
{
    public int line_id;
    public string response_option;
    public int guide;
    
}

[System.Serializable]
public struct AnimationFrames
{
    public Sprite[] frames;
}

[System.Serializable]
public struct DialogueLine
{
    public string dialogueLine;
    public int spriteID;
}

[CreateAssetMenu(fileName = "Dialogue Base", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogueBase : ScriptableObject
{
    // Make custom Class called Dialogue
    // Needs Text, and Options, and ID
    [SerializeField]
    DialogueLine[] dialogue_lines;

    [SerializeField]
    DialogueOptions[] dialogue_options;

    [SerializeField]
    AnimationFrames[] SpriteAnimationFrames;
    
    public DialogueOptions[] getOptions()
    {
        return dialogue_options;
    }

    public DialogueLine[] getLines()
    {
        return dialogue_lines;
    }

    public AnimationFrames[] getSprites()
    {
        return SpriteAnimationFrames;
    }

}
