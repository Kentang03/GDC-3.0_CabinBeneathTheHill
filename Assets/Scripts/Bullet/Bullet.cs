using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletDamage = 10f;

    private Transform target;

    private void Awake()
    {

        StartCoroutine(BulletDestroy());
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);

    }
}
