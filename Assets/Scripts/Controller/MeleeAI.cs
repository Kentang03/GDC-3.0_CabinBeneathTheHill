using UnityEngine;

[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Mover))]
class MeleeAI : MonoBehaviour 
{
    private Fighter fighter;
    private Health health;
    private Mover mover;
    private GameObject[] enemies;
    private GameObject enemy;

    [Header("Customize Drop")]
    [Range(0, 100)]
    [SerializeField] private int crystalWeigth;
    [Range(0, 100)]
    [SerializeField] private int soulWeigth;
    [Range(0, 100)]
    [SerializeField] private int noneWeigth;
    [SerializeField] private int dropAmount;

    private bool isDropped = false;

    private void Start()
    {
        fighter = GetComponent<Fighter>();
        health = GetComponent<Health>();
        mover = GetComponent<Mover>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }

    private void Update()
    {

    }  
}