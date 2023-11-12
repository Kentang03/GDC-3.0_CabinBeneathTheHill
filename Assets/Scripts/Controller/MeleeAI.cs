using System;
using UnityEngine;

class MeleeAI : MonoBehaviour
{
    public AdwinSO adwinStats;
    private Fighter fighter;
    private Mover mover;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject target;

    private Vector3 guardPosition;

    [SerializeField] float chaseDistance = 6f;

    private void Start()
    {
        guardPosition = transform.position;
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
        chaseDistance = adwinStats.skillPoints[3];
        // if no enemies and not in guard pos, move to guard pos
        if (!InGuardPosition() && !InAttackRangeOfPlayer())
        {
            mover.StartMoveAction(guardPosition, 1f);
        }

        else if (InAttackRangeOfPlayer() && fighter.CanAttack(target))
        {
            AttackBehaviour();
        }
    }



    public void FindEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private bool FoundEnemies()
    {
        FindEnemies();
        if (enemies == null) return false;
        else return true;
    }

    public void GetNearestEnemy()
    {
        FindEnemies();
        float nearestDistance = 1000000f;
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, enemies[i].transform.position);

            // if enemy dead, skip
            if (enemies[i].GetComponent<Health>().IsDead()) continue;

            if (distance < nearestDistance)
            {
                target = enemies[i];
                nearestDistance = distance;
            }

        }
    }

    private void AttackBehaviour()
    {
        fighter.Attack(target);
    }

    private bool InAttackRangeOfPlayer()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        return DistanceToPlayer <= chaseDistance;
    }

    private bool InGuardPosition()
    {
        float DistanceToGuardPosition = Vector3.Distance(transform.position, guardPosition);
        return DistanceToGuardPosition <= 0.01f;
    }

    public void UpdateAggro(Component sender, object data)
    {
        if (data is null)
        {
            target = null;
        }
    }

    // Called by Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}