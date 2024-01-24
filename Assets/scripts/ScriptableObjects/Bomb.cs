
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bomb", menuName = "Bomb/Create New Bomb")]
public class  Bomb: ScriptableObject
{
    public int id;
    public string bombName;
    public float bombRadius;
    public float bombSize;
    public bool isManual;
    public float timeToDetonate;
    public Sprite bombSprite;
    public Item inventoryVersion;
}
