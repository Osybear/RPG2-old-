using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask overlapMask;
    public Collider aggroPlayer;
    public float detectionRadius;
    public float attackDistance;
    public float attackSpeed;
    public int damage;
    public bool isAttacking;
    private Coroutine attackRoutine;

    private void FixedUpdate() {
        
    }
}
