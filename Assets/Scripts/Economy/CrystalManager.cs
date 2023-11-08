using UnityEngine;


public class CrystalManager : SingletonMonobehaviour<CrystalManager>
{
    [SerializeField] private EconomySO crystal;
    
    [Header("Events")]
    [SerializeField] GameEvent onCrystalChanged;
    [SerializeField] GameEvent onCrystalTotal;

    void Start() {
        onCrystalTotal.Raise(this, crystal.economyAmount);
    }

    public void IncreaseSoul(float amount)
    {
        crystal.economyAmount += amount;
        onCrystalChanged.Raise(this, amount);
        onCrystalTotal.Raise(this, crystal.economyAmount);
    }

    public void DecreaseSoul(float amount)
    {
        crystal.economyAmount -= amount;
        onCrystalChanged.Raise(this, amount);
        onCrystalTotal.Raise(this, crystal.economyAmount);
    }
}