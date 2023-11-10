using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "resource_", menuName = "Scriptable Object/UpgradeStats")]
public class UpgradeStatsSO : ScriptableObject
{
    public new string name;
    public int[] cost;

    public Sprite[] skillImage;



    // private void OnValidate()
    // {
    //     amount = 0;
    // }
}
