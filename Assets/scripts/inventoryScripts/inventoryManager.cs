using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{

    public static inventoryManager Instance;
    //public List<Item> items = new List<Item>();
    public Dictionary<Item, int> items = new Dictionary<Item, int>();
    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private Transform spawnPoint;

    private bool isInventoryOpen = false;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this; 
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ClearListItems();
        inventoryScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isInventoryOpen)
        {
            isInventoryOpen = true;
            inventoryScreen.SetActive(true);
            ClearListItems();
            ListItems();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isInventoryOpen)
        {
            isInventoryOpen = false;
            inventoryScreen.SetActive(false);
            ClearListItems();
        }
    }

    public void UseItem(Item item)
    {
        switch (item.type)
        {
            case 1:
                break;

            case 2:
                break;

            case 3:
                GameObject weaponInHand = spawnPoint.GetChild(0).gameObject;
                //RemoveFromHand(weaponInHand, weaponInHand.GetComponent<GunAttacks>());
                //AddToHand(item.realVersion, item);
                break;

        }
    }

    public void RemoveFromHand(GameObject weapon, Item itemVersion)
    {
        weapon.SetActive(false);
        Add(itemVersion, 1);
    }

    public void AddToHand(GameObject weaponInHand ,GameObject weapon, Item itemVersion)
    {
        Remove(itemVersion, 1);
        weaponInHand = weapon;
        weaponInHand.SetActive(true);

    }

    public void Add(Item item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item] += amount;
        }
        else
        {
            items.Add(item, amount);
        }
        
    }

    public void Remove(Item item, int amount)
    {
        if (items[item] - amount < 1)
        {
            items.Remove(item);
        }
        else
        {
            items[item] -= amount;
        }
    }

    public void ListItems()
    {
        if (InventoryItem == null || ItemContent == null)
        {
            Debug.LogError("InventoryItem or ItemContent is not assigned.");
            return;
        }

        foreach (var i in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = obj.transform.GetChild(1).GetComponent<Image>();
            var itemStackCount = obj.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>();

            Item i2 = i.Key;
            int amount = i.Value;
            
            itemName.text = i2.itemName; // Set the item name

            // Find the item with the given name in the items list
            
            itemIcon.sprite = i2.icon; // Set the item icon

            itemStackCount.text = "" + amount; // Set the stack count

            obj.GetComponent<itemController>().Item = i2;

            obj.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = i2.itemDescription;

        }
    }

    public void ClearListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }
}
