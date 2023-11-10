using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopup : MonoBehaviour
{
    public static TextPopup CreateDamage(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateSoul(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfSoulPopup, position, Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateCrystal(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfCrystalPopup, position, Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }

    private TextMeshPro textMesh;
    private float disappearTimer = 1f;
    private float disappearSpeed = 3f;
    private Color textColor;

    void Awake() {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int amount)
    {
        textMesh.SetText(amount.ToString());
        textColor = textMesh.color;
    }

    void Update()
    {
        float moveYSpeed = 2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        FadeOut();
    }

    private void FadeOut()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start Disappear
            disappearSpeed = Random.Range(1f, 3f);
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
