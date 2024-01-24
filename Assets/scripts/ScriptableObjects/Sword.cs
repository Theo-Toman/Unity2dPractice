using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Sword", menuName = "Sword/Create New Sword")]
public class Sword : ScriptableObject
{
    public int id;
    public string swordName;
    public int swordDamage;
    public float knockBackAmount;
    public float[] swordDimensions;
    public Item inventoryVersion;
}
