using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectTrigger : MonoBehaviour
{
    public AIDetectLogic detectLogic;

    private void Awake() {
        detectLogic = transform.parent.GetComponent<AIDetectLogic>();
    }

    private void OnTriggerEnter(Collider other) {
        detectLogic.AggroPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        detectLogic.DeAggroPlayer(other);
    }

    private void OnTriggerStay(Collider other) {
        detectLogic.SetAgentDestination(other);
    }
}
