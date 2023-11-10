using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float bulletDamage = 10f;

    private Transform target;

    void Awake() {
        StartCoroutine(BulletDestroy());
    }

    void Start() {
        direction = (target.position - transform.position).normalized;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            TextPopup.CreateDamage(transform.position, (int)bulletDamage);
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
