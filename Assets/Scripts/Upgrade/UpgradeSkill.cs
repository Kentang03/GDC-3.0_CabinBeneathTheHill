using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeSkill : MonoBehaviour
{
    public AdwinSO adwinStats;

    [SerializeField] private ResourceSO crystal;

    [SerializeField] GameEvent onCrystalChanged;

    [SerializeField] GameEvent onCrystalTotal;

    [SerializeField] private int upgradeInterval;

    [SerializeField] private int maxLevel;



    [SerializeField] private float[] upgradeCost;

    enum Stats { Stats1, Stats2, Stats3, Stats4 }
    [Header("Team Side")]
    [SerializeField] Stats stats;
    [SerializeField] private float upgradeIncrement;


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
                    UpgradeStats();
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

    void UpgradeStats()
    {
        if (stats == Stats.Stats1)
        {
            adwinStats.skillPoints[0] += upgradeIncrement;
            Debug.Log(adwinStats.skillPoints[0]);
        }

        if (stats == Stats.Stats2)
        {
            adwinStats.skillPoints[1] += upgradeIncrement;
        }

        if (stats == Stats.Stats3)
        {
            adwinStats.skillPoints[2] += upgradeIncrement;
        }

        if (stats == Stats.Stats4)
        {
            adwinStats.skillPoints[3] += upgradeIncrement;
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
