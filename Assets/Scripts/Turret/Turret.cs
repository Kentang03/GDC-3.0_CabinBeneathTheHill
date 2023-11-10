using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firingPoint;

    [Header("Atribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float bps = 1f;
    [SerializeField] private float fireCooldown = 1f;

    private Transform target;
    private float timeUntilFire;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime * fireCooldown;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }

        // RotateTowardTarget();
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefabs, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsRange()
    {
        // Debug.Log("ADA MUSUH");
        return Vector2.Distance(target.position, transform.position) <= targetingRange;

    }

    // private void RotateTowardTarget()
    // {
    //     float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

    //     Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    //     turretRotationPoint.rotation = targetRotation;
    // }



    private void OnDrawGizmos()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

}
