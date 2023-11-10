using UnityEngine;
using System.Collections;
using System;

class EnemyAI : MonoBehaviour 
{
    private Fighter fighter;
    private Health health;
    private GameObject playerBase;
    private Mover mover;
    private Drop drop;
    private SpriteRenderer spriteRenderer;
    private Collider2D coll2D;

    Color imageColor;

    [SerializeField] private GameEvent onEnemyDead;
    [SerializeField] private GameEvent onEnemySpawn;

    private bool isDropped = false;

    private void Start()
    {
        drop = GetComponent<Drop>();
        fighter = GetComponent<Fighter>();
        health = GetComponent<Health>();
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll2D = GetComponent<Collider2D>();


        imageColor = spriteRenderer.color;
        playerBase = GameObject.FindWithTag("PlayerBase");

        onEnemySpawn.Raise(this);

        fighter.Attack(playerBase);

    }

    private void Update()
    {
        if (health.IsDead() && !isDropped)
        {
            drop.DropResource();

            isDropped = true;
        }

        if (health.IsDead()) 
        {
            StartCoroutine(FadeOut());
            
            return;
        }

    }  

    private IEnumerator FadeOut()
    {
        coll2D.enabled = false;
        fighter.Cancel();
        yield return new WaitForSeconds(0.5f);

        float disappearSpeed = 2f;
        imageColor.a -= disappearSpeed * Time.deltaTime;
        spriteRenderer.color = imageColor;
        
        if (imageColor.a < 0)
        {
            onEnemyDead.Raise(this);
            Destroy(gameObject);

        }  
    }

}