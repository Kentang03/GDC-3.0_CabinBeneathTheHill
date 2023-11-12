using UnityEngine;
using TMPro;

class BaseHealth : MonoBehaviour {

    private GameObject playerBase;

    private float maxHealthPoints;
    private float healthPoints;

    [SerializeField] TextMeshPro healthText;

    void Start() {
        playerBase = GameObject.FindWithTag("PlayerBase");
    }

    void Update() {
        healthPoints =playerBase.GetComponent<Health>().GetHealthPoints();
        maxHealthPoints = playerBase.GetComponent<Health>().GetMaxHealthPoints();

        SetHealthText(); 
    }

    void SetHealthText()
    {
        int tempMaxHP = (int) maxHealthPoints;
        int tempHP = (int) healthPoints;
        healthText.SetText(tempHP.ToString() + " / " + tempMaxHP.ToString());
    }

}