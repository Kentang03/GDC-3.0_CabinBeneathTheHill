using UnityEngine;
using TMPro;

public class SoulText : MonoBehaviour
{
    TextMeshProUGUI soulText;

    void Awake()
    {
        soulText = GetComponent<TextMeshProUGUI>();
        soulText.text = "";
    }

    void SetSoul(float amount)
    {
        soulText.text = string.Format("{0:0}", amount);
    }
    
    // total soul
    public void UpdateText(Component sender, object data)
    {
        if (data is float)
        {
            float amount = (float) data;
            SetSoul(amount);
        }
    }
}