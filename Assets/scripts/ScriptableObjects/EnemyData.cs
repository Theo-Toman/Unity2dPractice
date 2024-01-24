using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Enemy Data/Create New Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int enemyMaxHealth;
    public int enemyDefence;
    public int enemyStrength;
    public int enemySpeed;
}
