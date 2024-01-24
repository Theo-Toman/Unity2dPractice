using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueResponse
{
    public int nextBranchID;
    public int nextTreeID;
    public string responceDialogue;
}

[System.Serializable]
public class DialogueChange
{
    public string variableName;
    public float valueChange;
    public bool boolChange;
    public string stringChange;
}

[System.Serializable]
public class DialogueBranche
{   
    public int branchID;
    public DialogueResponse[] responces;
    public string[] dialogue;
    public bool endOnFinal;
    public DialogueChange[] thingsToChange;
}

[System.Serializable]
public class DialogueTree
{
    public string branchName;
    public int dialogueTreeInt;
    public DialogueBranche[] branches;
}

[System.Serializable]
public class DialogueHolder
{
    public string name;

    public DialogueTree[] trees;
}
