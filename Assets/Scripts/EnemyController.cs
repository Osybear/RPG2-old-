using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{   
    private NavMeshAgent agent;
    private Coroutine attackRoutine;
    public Collider aggroPlayer;

    public void AggroPlayer(Collider other) {
        if(aggroPlayer == null)
            aggroPlayer = other;
    }

    public void DeAggroPlayer(Collider other) {
        if(other == aggroPlayer)
            aggroPlayer = null;
    }

    public void SetAgentToPlayer(Collider other) {
        if(aggroPlayer != null && other == aggroPlayer) {
            agent.SetDestination(aggroPlayer.transform.position);
        }
    }

    public void SetAttackToPlayer(Collider other) {
        if(other == aggroPlayer) {
            
        }
    }

    public IEnumerator AttackPlayerOverTime() {
        while(true) {
            yield return new WaitForSeconds();
        }
    }
}
