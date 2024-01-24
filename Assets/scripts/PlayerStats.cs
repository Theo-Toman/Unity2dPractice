using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public GameObject weaponAttacks;
    public string secondClass;

    public Animator playerApperance;

    public string playerName;
    public string[] playerPronouns;

    public int[] stats = new int[6]; //strengh, constitution, speed, intelegence, ceativity, speach

    private void Awake()
    {
        Instance = this;
    }

    

}
