using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * 10f;     
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string objName = col.gameObject.name;
        Debug.Log(objName);
        switch (objName)
        {
            case "Enemy(Clone)":
                col.gameObject.GetComponent<HealthManagerEnemy>().TakeDamage(10, 50f, transform);
                break;
            case "Enemy":
                col.gameObject.GetComponent<HealthManagerEnemy>().TakeDamage(10, 50f, transform);
                break;
        }

        Destroy(gameObject);
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
