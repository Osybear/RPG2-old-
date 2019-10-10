using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyController enemyController;

    private void Awake() {
        enemyController = transform.parent.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other) {
        enemyController.AttackPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        enemyController.StopAttackPlayer(other);
    }
}
