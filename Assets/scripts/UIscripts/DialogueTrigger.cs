using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueHolder dialogue;

    private void Start()
    {
    }

    public DialogueHolder TriggerDialogue(int myDialogueTreeIndex, int myDialogueBrancheIndex, string currentName)
    {
        dialogue.name = currentName;

        DialogueManager.Instance.StartDialogue(dialogue, myDialogueTreeIndex, myDialogueBrancheIndex);

        return dialogue;
    }
}
