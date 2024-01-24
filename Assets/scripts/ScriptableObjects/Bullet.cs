using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet/Create New Bullet")]
public class Bullet : ScriptableObject
{
    public int id;
    public string bulletName;
    public Item inventoryVersion;
}
