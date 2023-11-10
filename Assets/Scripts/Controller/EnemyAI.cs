using UnityEngine;

class EnemyAI : MonoBehaviour 
{
    private Fighter fighter;
    private Health health;
    private GameObject playerBase;
    private Mover mover;
    private Drop drop;

    private bool isDropped = false;

    private void Start()
    {
        drop = GetComponent<Drop>();
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
            drop.DropResource();
            isDropped = true;
        }

        if (health.IsDead()) return;


    }

  
}