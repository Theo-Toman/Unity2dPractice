using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject weaponAttacks;
    [SerializeField] private Animator animator;

    public DialogueHolder playerDialogue;

    private float horizontalInput;
    private float verticalInput;

    private float strength;
    private float constitution;
    private float speed;
    


    //private float direction;
    //private Vector3 difference;

    public int points;

    private string playerName;
    //private int playerMaxHealth = 100;
    private int playerCurrentHealth = 100;

    private GameObject attackingStuff;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerData data = SaveSystem.LoadPlayer();
        UpdatePlayerStats();
        attackingStuff = Instantiate(weaponAttacks, spawnPoint.position, spawnPoint.rotation);
        attackingStuff.transform.parent = spawnPoint.gameObject.transform;
        //animator = PlayerStats.Instance.playerAnimator;

        Debug.Log(attackingStuff.name);

        if (attackingStuff.name == "gunAttacks(Clone)")
        {
            spawnPoint.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    { 
        if (DialogueManager.Instance.dialogueIsActive)
        {
            horizontalInput = 0f;
            verticalInput = 0f;
            return;
        }

        //Debug.Log(anim.GetCurrentAnimatorClipInfo(0).Length);
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("going to next scene");
            levelManager.Instance.LoadScene("scene2");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            points++;
            Debug.Log(points);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Saving");
            SaveSystem.SavePlayer(this);
            Debug.Log("Saved");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Loading");
            PlayerData data = SaveSystem.LoadPlayer();
            points = data.Points;
            Debug.Log("Loaded");
        }
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime, 0f);
    }

    void FixedUpdate()
    {
        
     }

    public void TakeDamage(int damage)
    {
       playerCurrentHealth -= damage;
    }

    public void UpdateStats()
    {

    }

    public void UpdateWeapon(GameObject weaponToAdd)
    {
        Destroy(attackingStuff);

        attackingStuff = Instantiate(weaponToAdd, spawnPoint.position, transform.rotation);
        attackingStuff.transform.parent = this.gameObject.transform;
    }

    public void UpdatePlayerStats()
    {
        //strengh, constitution, speed, intelegence, ceativity, speach
        strength = PlayerStats.Instance.stats[0];
        constitution = PlayerStats.Instance.stats[1];
        speed = PlayerStats.Instance.stats[2] + 1;
    }

}
