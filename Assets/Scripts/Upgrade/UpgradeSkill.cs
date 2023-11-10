using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeSkill : MonoBehaviour
{

    [SerializeField] private ResourceSO crystal;

    [SerializeField] GameEvent onCrystalChanged;

    [SerializeField] GameEvent onCrystalTotal;

    [SerializeField] private int upgradeInterval;

    [SerializeField] private int maxLevel;


    [SerializeField] private float[] upgradeCost;




    private int costMark = 0;
    private int upgradeMark = 0;

    public int currentLevel;


    void Update()
    {
        // Array.Resize(ref upgradeCost, upgradeCost.Length + maxLevel / upgradeInterval);

    }

    private void OnValidate()
    {
        Array.Resize(ref upgradeCost, maxLevel / upgradeInterval);
    }

    public void UpgradePrice()
    {
        if (currentLevel < maxLevel)
        {
            if (upgradeMark != upgradeInterval)
            {
                if (crystal.amount >= upgradeCost[costMark])
                {
                    upgradeMark += 1;
                    UpgradeSkills(upgradeCost[costMark]);
                    Debug.Log(costMark);
                    Debug.Log(currentLevel);
                    Debug.Log(upgradeCost[costMark]);
                }
                else
                {
                    Debug.Log("Crystal Tidak Mencukupi");
                }
            }
            else
            {
                costMark += 1;
                upgradeMark = 0;

            }

        }
        else
        {
            Debug.Log("Level Telah Maksimal");
        }

    }

    public void UpgradeUICost(float cost)
    {
        onCrystalChanged.Raise(this, cost);
    }

    public void UpgradeSkills(float amount)
    {
        crystal.amount -= amount;
        if (currentLevel <= maxLevel)
            currentLevel += 1;
        onCrystalChanged.Raise(this, amount);
        onCrystalTotal.Raise(this, crystal.amount);
    }
}
