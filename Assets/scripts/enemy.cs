using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float vissionRange = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private fieldOfView FOV;



    private Rigidbody2D rb;

    private bool playerSeen = false;

    private DialogueTrigger dialogueScript;

    private int myDialogueTreeIndex = 0;
    private int myDialogueBrancheIndex = 0;

    private DialogueChange[] changing;
    private DialogueHolder tempDialogue;

    private string enemyName = "Enemy";

    private bool friendly = false;

    private float direction;
    private Vector3 difference = new Vector3(0f, 0f, 0f);

    private float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = gameObject.GetComponent<DialogueTrigger>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionOfPlayer = FOV.FieldOfView(90f, 45f);
        Debug.Log(directionOfPlayer);
        if (directionOfPlayer.magnitude > 0.001f)
        {
            transform.rotation = Quaternion.Euler(directionOfPlayer.x, directionOfPlayer.y, 0f);
            rb.velocity = transform.forward * speed;
        }

        if (DialogueManager.Instance.dialogueIsActive)
        {
            myDialogueTreeIndex = DialogueManager.Instance.dialogueTreeIndex;
            myDialogueBrancheIndex = DialogueManager.Instance.dialogueBrancheIndex;
            return;
        }

        if (false)
        {
            difference = transform.position - playerPos.position;
            difference.Normalize();  
            direction = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
            playerSeen = true;
        } 
        else if (!playerSeen)
        {
            Vector3 addAmount = new Vector3(0.1f, 0.1f, 0f);
            addAmount.Normalize();
            difference += addAmount;
            //difference = playerPos.rotation;
        }

        transform.rotation = Quaternion.Euler(-playerPos.rotation.x, -playerPos.rotation.y, -playerPos.rotation.z);

        rb.velocity = transform.forward * speed;
        

        

        Collider2D[] startDialogueWithPlayer = Physics2D.OverlapCircleAll(transform.position, vissionRange + 1f, playerMask);
        
        if (startDialogueWithPlayer.Length != 0 && Input.GetKeyDown(KeyCode.Space) && !DialogueManager.Instance.dialogueIsActive && 1 == 2)
        {
            if (friendly)
            {
                switch (myDialogueTreeIndex)
                {
                    case 1:
                        myDialogueTreeIndex = 3;
                        break;
                    case 3:
                        myDialogueTreeIndex = 5;
                        break;
                }
            }
            else
            {
                switch (myDialogueTreeIndex)
                {
                    case 0:
                        break;
                    case 1:
                        myDialogueTreeIndex = 3;
                        break;
                    case 2:
                        myDialogueTreeIndex = 4;
                        break;
                }
            }

            tempDialogue = dialogueScript.TriggerDialogue(myDialogueTreeIndex, myDialogueBrancheIndex, enemyName);
        }
        else if (tempDialogue != null)
        {
            changing = tempDialogue.trees[myDialogueTreeIndex].branches[myDialogueBrancheIndex].thingsToChange;
            foreach(var change in changing)
            {
                Debug.Log(change.variableName);
                switch (change.variableName)
                {
                    case "changeHealth":
                        //currentHealth += (int)change.valueChange;
                        break;

                    case "changeName":
                        enemyName = change.stringChange;
                        break;

                    case "isFriendly":
                        friendly = true;
                        break;

                }
            }

            tempDialogue = null;
            
        }


    }
}
