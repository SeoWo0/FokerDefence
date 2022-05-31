using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private Animator        animator;
    private NavMeshAgent    navMeshAgent;

    private void Awake() {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {

        animator.SetFloat("Move", navMeshAgent.velocity.magnitude);

    }
}
