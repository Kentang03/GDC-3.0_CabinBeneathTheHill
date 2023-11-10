using System;
using Unity.VisualScripting;
using UnityEngine;

class MeleeAI : MonoBehaviour
{
    private Fighter fighter;
    private Mover mover;
    private GameObject[] enemies;
    private GameObject enemy;

    private Vector3 guardPosition;

    [SerializeField] float chaseDistance = 6f;

    private void Start()
    {
        guardPosition = transform.position;
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        if (enemies != null)
        {
            // if no target, then find closest target
            if (enemy == null) GetNearestEnemy();
        }

        // if no enemies and not in guard pos, move to guard pos
        else if (enemies == null && !InGuardPosition())
        {
            mover.StartMoveAction(guardPosition, 1f);
        }

        // if enemy in attack range, then Attack Enemy
        if (InAttackRangeOfPlayer() && fighter.CanAttack(enemy))
        {
            AttackBehaviour();
        }
    }

    public void GetNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float nearestDistance = 1000000f;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, enemies[i].transform.position);

            // if enemy dead, skip
            if (enemies[i].GetComponent<Health>().IsDead()) continue;

            if (distance < nearestDistance)
            {
                enemy = enemies[i];
                nearestDistance = distance;
            }

        }
    }

    private void AttackBehaviour()
    {
        fighter.Attack(enemy);
    }

    private bool InAttackRangeOfPlayer()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, enemy.transform.position);
        return DistanceToPlayer <= chaseDistance;
    }

    private bool InGuardPosition()
    {
        float DistanceToGuardPosition = Vector3.Distance(transform.position, guardPosition);
        return DistanceToGuardPosition <= 0.01f;
    }

    // Called by Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}