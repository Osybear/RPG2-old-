using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackTrigger : MonoBehaviour
{
    public AIAttackLogic aIAttackLogic;

    private void Awake() {
        aIAttackLogic = transform.parent.GetComponent<AIAttackLogic>();
    }

    private void OnTriggerEnter(Collider other) {
        aIAttackLogic.AttackPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        aIAttackLogic.StopAttackPlayer(other);
    }
}
