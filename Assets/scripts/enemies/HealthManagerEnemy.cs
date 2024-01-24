using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManagerEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject hitText;
    [SerializeField] private GameObject c;

    private int maxHealth;
    private int currentHealth;

    private Rigidbody2D rb;

    private float invinibleTimeAmount = 3;
    private float invincable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        maxHealth = enemyData.enemyMaxHealth;
        currentHealth = enemyData.enemyMaxHealth;
        slider.maxValue = maxHealth;
    }

    // Update is called once per frame

    public void TakeDamage(int damage, float knockBackForce, Transform hitterPos)
     {
        if (invinibleTimeAmount > Time.deltaTime - invincable)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }

            

            Vector2 direction = (transform.position - hitterPos.position).normalized;

            Vector2 knockBack = direction * knockBackForce;

            GameObject thing = Instantiate(hitText, transform.position, transform.rotation);
            thing.transform.SetParent(c.transform);

            thing.GetComponent<DamageTaken>().StartFunctions(damage, direction);

            slider.value = currentHealth;



            

            rb.AddForce(knockBack, ForceMode2D.Impulse);
            invincable = Time.deltaTime;
        }
     }
}
