using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAttack : MonoBehaviour
{
    [SerializeField] private LayerMask EnemyMask;
    [SerializeField] private GameObject sword;
    [SerializeField] private Sword swordData;
    [SerializeField] GameObject playerPos;

    [SerializeField] private Animator animator;

    List<Collider2D> enemiesAlreadyHit = new List<Collider2D>();

    private float knockBackForce;
    private GameObject weapon;
    private bool spawnedSword = false;

    private Transform pointChild;

    private AnimationClip clip;

    private bool deSpawn = false;

    private int damage;
    private float[] colliderDimension;

    private float direction;
    private Vector3 difference;

    //private int currentSortingLayer = 1;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        damage = swordData.swordDamage;
        //anim = swordData.swordAnimation;
        colliderDimension = swordData.swordDimensions;
        pointChild = transform.GetChild(0);
        animator = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        knockBackForce = swordData.knockBackAmount;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spawnedSword)
        {
            animator.SetBool("Attack", true);
        }
        else if (deSpawn)
        {
            animator.SetBool("Attack", false);
            deSpawn = false;
        }

        if (Input.GetAxis("Horizontal") > 0f)
        {
            sprite.sortingOrder = -1;
        }
        else if (Input.GetAxis("Horizontal") < 0f)
        {
            sprite.sortingOrder = 1;
        }
    }

    // Update is called once per frame

    public void CheckForEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, colliderDimension[1], EnemyMask);
        foreach(Collider2D enemy in hitEnemies)
        {
            if (!enemiesAlreadyHit.Contains(enemy))
            {
                string objName = enemy.gameObject.name;
                Debug.Log(objName);
                switch (objName)
                {
                    case "Enemy(Clone)":
                        enemy.gameObject.GetComponent<HealthManagerEnemy>().TakeDamage(damage, knockBackForce, transform);
                        break;
                    case "Enemy":
                        enemy.gameObject.GetComponent<HealthManagerEnemy>().TakeDamage(damage, knockBackForce, transform);
                        break;
                }
                enemiesAlreadyHit.Add(enemy);
            }
            
        }
    }

    public void EndAnimation()
    {
        deSpawn = true;
        enemiesAlreadyHit.Clear();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderDimension[1]);
    }
}
