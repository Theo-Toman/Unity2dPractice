using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private LayerMask playerMask;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 0.7f, playerMask);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                inventoryManager.Instance.Add(item, 1);
                Destroy(gameObject);
            }

            inventoryManager.Instance.ClearListItems();
            inventoryManager.Instance.ListItems();
            
        }
    }
}
