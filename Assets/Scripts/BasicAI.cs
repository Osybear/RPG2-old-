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
        if(aggroPlayer != null && agent.remainingDistance < attackDistance) {
            agent.isStopped = true;
            isAttacking = true;
        }

        if(isAttacking == true && attackRoutine == null) {
            attackRoutine = StartCoroutine(Attack());
        }

        if(aggroPlayer == null) {
            aggroPlayer = GetNearestPlayer();
        }

        if(aggroPlayer != null) {
            agent.SetDestination(aggroPlayer.transform.position);
        }
    }

    public IEnumerator Attack() {
        while(Vector3.Distance(transform.position, aggroPlayer.transform.position) < attackDistance) {
            yield return new WaitForSeconds(attackSpeed);
            Health health = aggroPlayer.GetComponent<Health>();
            health.OnDamage(damage);
        }

        isAttacking = false;
        attackRoutine = null;
        agent.isStopped = false;
        yield return null;
    }

    public Collider GetNearestPlayer() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, overlapMask);
        
        if(hitColliders.Length == 0)
            return null;

        if(hitColliders.Length == 1)
            return hitColliders[0];

        Collider nearestCollider = hitColliders[0];

        for (int i = 1; i < hitColliders.Length; i++) {
            if(Vector3.Distance(transform.position, hitColliders[i].transform.position) < Vector3.Distance(transform.position, nearestCollider.transform.position)) {
                nearestCollider = hitColliders[i];
            }
        }

        return nearestCollider;
    }
}
