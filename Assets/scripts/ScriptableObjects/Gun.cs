using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Gun", menuName = "Gun/Create New Gun")]
public class Gun : ScriptableObject
{
    public int id;
    public string gunName;
    public int gunAmmo;
    public float fireRate;
    public float reloadTime;
    public Item inventoryVersion;
}
