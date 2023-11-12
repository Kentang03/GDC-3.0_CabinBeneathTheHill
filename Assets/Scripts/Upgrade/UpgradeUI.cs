using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeStatsSO upgradeStats;
    public AdwinSO adwinStats;

    public TextMeshProUGUI nameCharacter;
    // public TextMeshProUGUI cost;

    public Image[] skillBox;

    public TextMeshProUGUI[] nameStats;


    private void Update()
    {
        nameCharacter.text = upgradeStats.name;
        // cost.text = upgradeStats.cost.ToString();
        skillBox[0].sprite = upgradeStats.skillImage[0];
        skillBox[1].sprite = upgradeStats.skillImage[1];
        skillBox[2].sprite = upgradeStats.skillImage[2];

        nameStats[0].text = adwinStats.nameSkill[0];
        nameStats[1].text = adwinStats.nameSkill[1];
        nameStats[2].text = adwinStats.nameSkill[2];

        nameCharacter.text = adwinStats.nameCharacter;

    }


}
