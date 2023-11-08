using UnityEngine;

public class SoulManager : SingletonMonobehaviour<SoulManager>
{
    [SerializeField] private ResourceSO soul;
    
    [Header("Events")]
    [SerializeField] GameEvent onSoulChanged;
    [SerializeField] GameEvent onSoulTotal;

    void Start() {
        onSoulTotal.Raise(this, soul.amount);
    }

    public void IncreaseSoul(float amount)
    {
        soul.amount += amount;
        onSoulChanged.Raise(this, amount);
        onSoulTotal.Raise(this, soul.amount);
    }

    public void DecreaseSoul(float amount)
    {
        soul.amount -= amount;
        onSoulChanged.Raise(this, amount);
        onSoulTotal.Raise(this, soul.amount);
    }
}