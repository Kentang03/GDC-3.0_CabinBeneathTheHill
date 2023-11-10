
using UnityEngine;

[CreateAssetMenu(fileName = "resource_", menuName = "Scriptable Object/Resource")]
public class ResourceSO : ScriptableObject
{
    [SerializeField] public float amount;


    // private void OnValidate()
    // {
    //     amount = 0;
    // }
}
