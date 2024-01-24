using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public List<Item> itemRecipe = new List<Item>();
    public string itemDescription;
    public int type;
    public GameObject realVersion;
}
