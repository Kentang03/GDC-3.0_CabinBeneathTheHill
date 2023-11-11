using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeStatsSO upgradeStats;

    public TextMeshProUGUI nameCharacter;
    public TextMeshProUGUI cost;

    public Image skillImage1;
    public Image skillImage2;
    public Image skillImage3;
    public Image skillImage4;




    private void Start()
    {
        nameCharacter.text = upgradeStats.name;
        cost.text = upgradeStats.cost.ToString();
        skillImage1.sprite = upgradeStats.skillImage[0];
        skillImage2.sprite = upgradeStats.skillImage[1];
        skillImage3.sprite = upgradeStats.skillImage[2];
        skillImage4.sprite = upgradeStats.skillImage[3];
    }


}
