using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectTrigger : MonoBehaviour
{
    private EnemyController enemyController;

    private void Awake() {
        enemyController = transform.parent.GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other) {
        enemyController.AggroPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        enemyController.DeAggroPlayer(other);
    }

    private void OnTriggerStay(Collider other) {
        enemyController.SetAgentDestination(other);
    }
}
