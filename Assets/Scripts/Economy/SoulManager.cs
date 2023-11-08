using UnityEngine;

public class SoulManager : SingletonMonobehaviour<SoulManager>
{
    [SerializeField] private EconomySO soul;
    
    [Header("Events")]
    [SerializeField] GameEvent onSoulChanged;
    [SerializeField] GameEvent onSoulTotal;

    void Start() {
        onSoulTotal.Raise(this, soul.economyAmount);
    }

    public void IncreaseSoul(float amount)
    {
        soul.economyAmount += amount;
        onSoulChanged.Raise(this, amount);
        onSoulTotal.Raise(this, soul.economyAmount);
    }

    public void DecreaseSoul(float amount)
    {
        soul.economyAmount -= amount;
        onSoulChanged.Raise(this, amount);
        onSoulTotal.Raise(this, soul.economyAmount);
    }
}