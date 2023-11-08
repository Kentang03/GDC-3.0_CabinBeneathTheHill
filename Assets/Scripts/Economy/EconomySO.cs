
using UnityEngine;

[CreateAssetMenu(fileName = "economy_", menuName = "Scriptable Object/Economy")]
public class EconomySO : ScriptableObject
{
    [SerializeField] public float economyAmount;
}
