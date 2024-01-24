using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    
    [SerializeField] private TextMeshProUGUI TextBox;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private GameObject thing;
    [SerializeField] private Button someButton;

    [SerializeField] private GameObject playerChoicesButton;
    [SerializeField] private Transform choicesSpawnPoint;

    public DialogueTree dialogue;
    public int dialogueTreeIndex;
    public int dialogueBrancheIndex;
    List<GameObject> buttons =  new List<GameObject>();

    private Queue<string> sentences;

    public bool dialogueIsActive = false;

   
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        sentences = new Queue<string>();
        thing.SetActive(false);
    }

    public void StartDialogue(DialogueHolder dialogue2, int dialogueTreeIndex, int dialogueBrancheIndex2)
    {
        
        dialogueBrancheIndex = dialogueBrancheIndex2;
        dialogue = dialogue2.trees[dialogueTreeIndex];
        dialogueIsActive = true;

        if (dialogue.branches.Length < dialogueBrancheIndex)
        {
            sentences.Enqueue(dialogue.branches[dialogueBrancheIndex].dialogue[^1]);
        }
        else
        {
            speakerName.text = dialogue2.name;

            sentences.Clear();

            foreach (string sentence in dialogue.branches[dialogueBrancheIndex].dialogue)
            {
                sentences.Enqueue(sentence);
            }
        }

        thing.SetActive(true);

        ShowNextText();

    }

    public void ShowNextText()
    {
        for (int i = buttons.Count - 1; i >= 0; i--)
        {
            Destroy(buttons[i]);
            buttons.RemoveAt(i);
        }

        if (sentences.Count == 0)
        {
            if (dialogue.branches[dialogueBrancheIndex].endOnFinal)
            {
                TextBox.text = "";
                thing.SetActive(false);
                dialogueIsActive = false;
            }
            else 
            {
                playerChoice(dialogue.branches[0]);
            }
            
        }
        else
        {
            string sentence = sentences.Dequeue();

            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        
    }

    private void playerChoice(DialogueBranche playerDialogue)
    {
        
        foreach (var choice in playerDialogue.responces)
        {
            GameObject playerChoice = Instantiate(playerChoicesButton, choicesSpawnPoint.position, transform.rotation);
            playerChoice.transform.SetParent(choicesSpawnPoint);
        
            playerChoice.transform.position += new Vector3(0f, 60f * buttons.Count - 1f, 0f);

            playerChoice.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = choice.responceDialogue;

            playerChoice.GetComponent<Button>().onClick.AddListener(() => GetPlayerChoice(choice.nextBranchID));
            
            buttons.Add(playerChoice);
        }
    }

    public void GetPlayerChoice(int nextBranch)
    {
        dialogueBrancheIndex = nextBranch;
        sentences.Clear();
        foreach (string sentence in dialogue.branches[0].dialogue)
        {
            sentences.Enqueue(sentence);
        }

        ShowNextText();
    }

    IEnumerator TypeSentence(string sentence)
    {
        TextBox.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            TextBox.text += letter;
            yield return null;
        }
    }
}
