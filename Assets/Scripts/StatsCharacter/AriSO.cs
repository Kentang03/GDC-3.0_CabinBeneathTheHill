using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "resource_", menuName = "Scriptable Object/ari")]
public class AriSO : ScriptableObject
{
    public string nameCharacter;
    public string[] nameSkill;


    // public float maxHealth;
    public float[] skillPoints;

    private void OnValidate()
    {
        Array.Resize(ref skillPoints, nameSkill.Length);
    }

}
