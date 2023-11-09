using UnityEngine;

[RequireComponent(typeof(ActionScheduler))]
[RequireComponent(typeof(CombatTarget))]
[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Mover))]
class EnemyAI : MonoBehaviour 
{
    private Fighter fighter;
    private Health health;
    private GameObject playerBase;
    private Mover mover;

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
        playerBase = GameObject.FindWithTag("PlayerBase");

        fighter.Attack(playerBase);

    }

    private void Update()
    {
        if (health.IsDead() && !isDropped)
        {
            isDropped = true;
            DropResource();
        }

        if (health.IsDead()) return;


    }

    private void DropResource()
    {
        int sumWeigth = crystalWeigth + soulWeigth + noneWeigth;
        int randomNum = Random.Range(0, sumWeigth);

        if (randomNum <= crystalWeigth)
        {
            CrystalManager.Instance.IncreaseCrystal(dropAmount);
        }

        else if (randomNum > crystalWeigth && randomNum <= soulWeigth + crystalWeigth)
        {
            SoulManager.Instance.IncreaseSoul(dropAmount);
        }

    }
  
}