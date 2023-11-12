using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopup : MonoBehaviour
{
    public static TextPopup CreateDamage(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position + RandomPosition(), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateEnemyDamage(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfEnemyDamagePopup, position + RandomPosition(), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateSoul(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfSoulPopup, position + RandomPosition(), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateCrystal(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfCrystalPopup, position + RandomPosition(), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }
    public static TextPopup CreateHeal(Vector3 position, int amount)
    {
        Transform textPopupTransform = Instantiate(GameAssets.Instance.pfHealPopup, position + RandomPosition(), Quaternion.identity);
        TextPopup textPopup = textPopupTransform.GetComponent<TextPopup>();
        textPopup.Setup(amount); 

        return textPopup;
    }

    private TextMeshPro textMesh;
    private float disappearTimer = 0.5f;
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
    private static Vector3 RandomPosition()
    {
        return new  Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
    }

    private void FadeOut()
    {
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            // Start Disappear
            float disappearSpeed = Random.Range(1f, 3f);
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
