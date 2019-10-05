using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask overlapMask;
    public GameObject tempPlayer;
    public float radius;

    private void FixedUpdate() {
        
    }

    public void GetNearestPlayer() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, overlapMask);

        foreach(Collider col in hitColliders) {
            
        }
    }
}
