using UnityEngine;
using TMPro;

public class CrystalText : MonoBehaviour
{
    TextMeshProUGUI crystalText;

    void Awake()
    {
        crystalText = GetComponent<TextMeshProUGUI>();
        crystalText.text = "";
    }

    void SetCrystal(float amount)
    {
        crystalText.text = string.Format("{0:0}", amount);
    }
    
    // total crystal
    public void UpdateText(Component sender, object data)
    {
        if (data is float)
        {
            float amount = (float) data;
            SetCrystal(amount);
        }
    }
}