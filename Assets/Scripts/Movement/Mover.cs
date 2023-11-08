using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.AI;

public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] float maxSpeed = 6f;

        bool isStopped;
        
        Vector3 nextPosition;
        Health health;

        void Start()
        {   
            health = GetComponent<Health>();
        } 
        
        void Update()
        {
            if (isStopped) return;
            // navMeshAgent.enabled = !health.IsDead();
            // UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            isStopped = false;
            transform.position = Vector3.MoveTowards(transform.position, destination, maxSpeed * speedFraction * Time.deltaTime);
            // navMeshAgent.destination = destination;
            // navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        }

        public void Cancel()
        {
            isStopped = true;
            // navMeshAgent.isStopped = true;
        }

        // private void UpdateAnimator()
        // {
        //     // Vector3 velocity = navMeshAgent.velocity;
        //     // Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        //     // float speed = localVelocity.z;

        //     // GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        // }
    }