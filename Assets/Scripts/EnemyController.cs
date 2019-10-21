using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{   
    private NavMeshAgent agent;
    private Coroutine attackRoutine;
    public Collider aggroPlayer;
    public float attackSpeed;
    public int damage;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();    
    }

    public void AggroPlayer(Collider other) {
        if(aggroPlayer == null) 
            aggroPlayer = other;
    }

    public void DeAggroPlayer(Collider other) {
        if(other == aggroPlayer)
            aggroPlayer = null;
    }

    public void SetAgentDestination(Collider other) {
        if(aggroPlayer != null && other == aggroPlayer) {
            agent.SetDestination(aggroPlayer.transform.position);
        }
    }

    public void AttackPlayer(Collider other) {
        if(other == aggroPlayer) {
            attackRoutine = StartCoroutine(AttackPlayerOverTime());
            //agent.isStopped = true;
        }
    }

    public void StopAttackPlayer(Collider other) {
        if(other == aggroPlayer) {
            StopCoroutine(attackRoutine);
            //agent.isStopped = false;
        }
    }

    public IEnumerator AttackPlayerOverTime() {
        while(true) {
            yield return new WaitForSeconds(attackSpeed);
            Health health = aggroPlayer.GetComponent<Health>();
            health.Damage(damage);
        }
    }
}
