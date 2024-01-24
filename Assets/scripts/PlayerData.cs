using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
   //public string playerName;
   //public string playerPronouns1;
   //public string playerPronouns2;
   //public Sprite characterLooks;

   //game stats
   //public int strength;
   //public int speed;
   //public int constitution;
   //public int speech;
   //public int intelegence;
   //public int creativity;

   //public int health;

   public int Points;

   public PlayerData (Player player)
   {
		Points = player.points;
   }


}
