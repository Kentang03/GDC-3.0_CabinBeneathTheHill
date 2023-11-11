using UnityEngine;


public class CrystalManager : SingletonMonobehaviour<CrystalManager>
{
    [SerializeField] private ResourceSO crystal;

    [Header("Events")]
    [SerializeField] GameEvent onCrystalChanged;
    [SerializeField] GameEvent onCrystalTotal;

    void Start()
    {
        onCrystalTotal.Raise(this, crystal.amount);
    }

    public void IncreaseCrystal(float amount)
    {
        crystal.amount += amount;
        onCrystalChanged.Raise(this, amount);
        onCrystalTotal.Raise(this, crystal.amount);
    }

    public void DecreaseCrystal(float amount)
    {
        crystal.amount -= amount;
        onCrystalChanged.Raise(this, amount);
        onCrystalTotal.Raise(this, crystal.amount);
    }
}