using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private Bomb bombData;
    [SerializeField] private LayerMask masksToCheck;
    private float bombTime;
    private bool playerControlled;
    private float explosionRange;
    // Start is called before the first frame update
    void Start()
    {
        bombTime = bombData.timeToDetonate * 50;
        playerControlled = bombData.isManual;
        explosionRange = bombData.bombRadius;
        
        gameObject.GetComponent<SpriteRenderer>().sprite = bombData.bombSprite;
        gameObject.AddComponent<CircleCollider2D>();
        CircleCollider2D sphere = gameObject.GetComponent<CircleCollider2D>();
        sphere.offset = Vector3.zero; // the center must be in local coordinates
        sphere.radius = bombData.bombRadius - 1.5f;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (playerControlled)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Explode();
            }
        }
    }

    void FixedUpdate()
    {
        if (!playerControlled)
        {
            if (bombTime < 0)
            {
                Explode();
            }
            else
            {
                bombTime --;
            }
            Debug.Log(bombTime);
        }


        
    }

    private void Explode()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRange, masksToCheck);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit " + enemy.name);
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemy.GetComponent<HealthManagerEnemy>().TakeDamage(30, 100f, transform);
            }
            else
            {
                enemy.GetComponent<Player>().TakeDamage(30);
            }
        }
        Destroy(gameObject);
    }

}
