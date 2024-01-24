using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class crafting: MonoBehaviour
{
    public static crafting Instance;
    [SerializeField] private Transform ItemContent;
    //[SerializeField] private GameObject InventoryItem;
    [SerializeField] private GameObject inventoryScreen;
    [SerializeField] private Sprite notIn;
    
    [SerializeField] private GameObject itemData;
    [SerializeField] private List<Item> craftingList = new List<Item>();

    private bool isInventoryOpen = false;

    private void Awake()
    {
        Instance = this; 
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ClearCraftingListItems();
        inventoryScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isInventoryOpen)
        {
            isInventoryOpen = true;
            inventoryScreen.SetActive(true);
            ClearCraftingListItems();
            ListCraftingItems();
        }
        else if (Input.GetKeyDown(KeyCode.R) && isInventoryOpen)
        {
            isInventoryOpen = false;
            inventoryScreen.SetActive(false);
            ClearCraftingListItems();
        }
    }

    

    private void ListCraftingItems()
    {
        foreach (var craftingItem in craftingList)
        {
            GameObject obj = Instantiate(itemData, ItemContent);
            var itemName = obj.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
            var itemIcon = obj.transform.GetChild(1).GetComponent<Image>();

            if (CheckCraft(craftingItem))
            {
                itemIcon.sprite = craftingItem.icon;
            }
            else
            {
                itemIcon.sprite = notIn;
            }

            itemName.text = craftingItem.itemName; // Set the item name

            GameObject descriptionBox = obj.transform.GetChild(3).gameObject;

            string recipeText = "";

            foreach (var r in craftingItem.itemRecipe)
            {
                recipeText += " " + r.itemName;
            }

            descriptionBox.GetComponent<TMPro.TextMeshProUGUI>().text = craftingItem.itemDescription + ": " + recipeText;

            obj.GetComponent<itemController>().Item = craftingItem;
        }
    }

    private void ClearCraftingListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    

    public bool CheckCraft(Item craftingItem)
    {
        Dictionary<Item, int> tempItems = inventoryManager.Instance.items;
        List<Item> tempRecipe = craftingItem.itemRecipe;
        int recipeLength = tempRecipe.Count;
        bool inventoryFound = false;

        foreach (var recipe in tempRecipe)
        {
            inventoryFound = false;
            do
            {
                if (tempItems.ContainsKey(recipe) && tempRecipe.Count(x => x == recipe) <= tempItems[recipe])
                {
                    inventoryFound = true;
                }
                else
                {
                    Debug.Log("Not in lol");
                    return false;
                }

            } while (!inventoryFound);
        }
        Debug.Log("IN!");
        return true;
    }


}
