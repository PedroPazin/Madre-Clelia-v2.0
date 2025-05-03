using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public struct Dialogue
{
    public string name;
    [TextArea(5, 10)]
    public string text;
}

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/TalkScript", order = 1)]
public class DialogueData : ScriptableObject
{
    public List<Dialogue> talkScript;
}
