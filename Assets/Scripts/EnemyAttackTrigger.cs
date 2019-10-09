using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyController enemyController;

    private void Awake() {
        transform.parent.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other) {
        
    }

    private void OnTriggerExit(Collider other) {
        
    }

    private void OnTriggerStay(Collider other) {
        
    }
}
