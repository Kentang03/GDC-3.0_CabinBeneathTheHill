using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "resource_", menuName = "Scriptable Object/Ari")]
public class AriSO : ScriptableObject
{
    public float heal;
    public float regen;

    public float healCooldown;

}
