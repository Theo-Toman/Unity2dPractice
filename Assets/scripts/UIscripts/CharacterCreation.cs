using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] private GameObject can;
    [SerializeField] private TextMeshProUGUI pointsRemainingText;
    [SerializeField] private TextMeshProUGUI[] StatsPoints;

    [SerializeField] private GameObject[] weaponClasses;
    //[SerializeField] private GameObject canvas;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Animator[] animators;
    [SerializeField] private GameObject player;

    [SerializeField] private int maxPoints;
    private int remainingPoints;

    private int sceneNum = 1;
    private Canvas canvas;
    private DestroyPanel panelScript;

    private string tempName = "Name";
    // Start is called before the first frame update
    void Start()
    {
        remainingPoints = maxPoints;
        canvas = can.GetComponent<Canvas>();
        panelScript = FindObjectOfType<DestroyPanel>();
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneNum)
        {
            case 1:
                //panelScript.destroyPanel();
                panels[0].SetActive(true);

                break;
            case 2:
                panels[0].SetActive(false);
                panels[1].SetActive(true);
                break;
            case 3:
                panels[1].SetActive(false);
                panels[2].SetActive(true);
                break;
        }
    }

    public void GetCharacterFirstClass(int classIndex)
    {
        PlayerStats.Instance.weaponAttacks = weaponClasses[classIndex];
        sceneNum++;
    }

    public void GetCharacterName(string s)
    {
        tempName = s;
        Debug.Log(s);
    }

    public void GetCharacterApperance(int animatorIndex)
    {
        //PlayerStats.Instance.playerAnimator = animators[animatorIndex];
        PlayerStats.Instance.playerName = tempName;
        sceneNum++;
    }

    public void updatePointsAdd(int statPointIndex)
    {
        if (remainingPoints == 0)
        {
            return;
        }
        PlayerStats.Instance.stats[statPointIndex] += 1;
        remainingPoints -= 1;
        StatsPoints[statPointIndex].text = "" + PlayerStats.Instance.stats[statPointIndex];
        pointsRemainingText.text = "Points Remaing: " + remainingPoints;
    }

    public void updatePointsSubtract(int statPointIndex)
    {
        PlayerStats.Instance.stats[statPointIndex] -= 1;
        remainingPoints += 1;
        StatsPoints[statPointIndex].text = "" + PlayerStats.Instance.stats[statPointIndex];
        pointsRemainingText.text = "Points Remaing: " + remainingPoints;
    }

    public void next()
    {
        foreach (var i in PlayerStats.Instance.stats)
        {
            Debug.Log(i);
        }
    }
}
