using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;

public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] float maxSpeed = 6f;
        
        [SerializeField] float speedPercentage = 1f;

        bool isStopped;
        
        Animator animator;
        Vector3 nextPosition;
        Health health;
        bool isLeft;

        void Start()
        {   
            animator = GetComponent<Animator>();
            health = GetComponent<Health>();
        } 
        
        void Update()
        {
            if (isStopped) return;
            // navMeshAgent.enabled = !health.IsDead();
            if (animator != null) UpdateAnimator();
            
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            isStopped = false;
            if (destination.x < transform.position.x) isLeft = true;
            else if (destination.x > transform.position.x) isLeft = false;
            transform.position = Vector3.MoveTowards(transform.position, destination, (maxSpeed * speedPercentage) * speedFraction * Time.deltaTime);
            // navMeshAgent.destination = destination;
            // navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        }

        public void Cancel()
        {
            isStopped = true;
            // navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            if (isLeft){
                animator.SetBool("IsLeft", true);
            }

            else{
                animator.SetBool("IsLeft", false);
            }
        }
    }