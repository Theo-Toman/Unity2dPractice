using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textStatsPoints;
    [SerializeField] private TextMeshProUGUI pointsRemainingText;
    [SerializeField] private TextMeshProUGUI weaponChoice;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] weapons;

    private int maxPoints = 20;
    private int remainingPoints;
    private int[] intStatPoints = new int[6];
    private bool StatsManagerOpen = false;

    private Player playerScript;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //DontDestroyOnLoad(HUD);
    }
    // Start is called before the first frame update
    void Start()
    {
        intStatPoints = PlayerStats.Instance.stats;
        remainingPoints = maxPoints;
        playerScript = player.GetComponent<Player>();
        foreach (var stat in intStatPoints)
        {
            remainingPoints -= stat;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (StatsManagerOpen)
            {
                //PlayerStats.Instance.stats = intStatPoints;
                //playerScript.UpdatePlayerStats();
                menu.SetActive(false);
                StatsManagerOpen = false;
            }
            else
            {
                menu.SetActive(true);
                StatsManagerOpen = true;
            }
        }
    }

    public void SaveStats()
    {
        switch (weaponChoice.text) 
        {
            case "Gun":
                PlayerStats.Instance.weaponAttacks = weapons[0];
                playerScript.UpdateWeapon(weapons[0]);
                break;
            case "Sword":
                PlayerStats.Instance.weaponAttacks = weapons[1];
                playerScript.UpdateWeapon(weapons[1]);
                break;
        }
    }

    public void updatePointsAdd(int statPointIndex)
    {
        if (remainingPoints == 0)
        {
            return;
        }
        intStatPoints[statPointIndex] += 1;
        remainingPoints -= 1;
        textStatsPoints[statPointIndex].text = "" + intStatPoints[statPointIndex];
        pointsRemainingText.text = "Points Remaing: " + remainingPoints;
    }

    public void updatePointsSubtract(int statPointIndex)
    {
        if (remainingPoints == 0)
        {
            return;
        }
        intStatPoints[statPointIndex] -= 1;
        remainingPoints += 1;
        textStatsPoints[statPointIndex].text = "" + intStatPoints[statPointIndex];
        pointsRemainingText.text = "Points Remaing: " + remainingPoints;
    }

}
