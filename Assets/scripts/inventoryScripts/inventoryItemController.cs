using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryItemController : MonoBehaviour
{
    public Item Item;

    [SerializeField] private Transform playerPos;
    private GameObject descriptoin1;
    private GameObject descriptoin2;

    private void Start()
    {
        descriptoin1 = transform.GetChild(3).gameObject;
        descriptoin2 = transform.GetChild(4).gameObject;
    }

    public void DisplayItemDescription(bool display)
    {
        descriptoin1.SetActive(display);
        descriptoin2.SetActive(display);
    }

    public void craftItem()
    {
        if (crafting.Instance.CheckCraft(Item))
        {
            foreach (var item in Item.itemRecipe)
            {
                inventoryManager.Instance.Remove(item, 1);
            }
            inventoryManager.Instance.Add(Item, 1);
            inventoryManager.Instance.ClearListItems();
            inventoryManager.Instance.ListItems();
        }
    }

    public void DropItem()
    {
        Instantiate(Item.realVersion, playerPos.position, playerPos.rotation);
        inventoryManager.Instance.Remove(Item, 1);
        inventoryManager.Instance.ClearListItems();
        inventoryManager.Instance.ListItems();
    }
}
