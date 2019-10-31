using UnityEngine;

public class AIAttackTrigger : MonoBehaviour
{
    private AIController aiController;

    private void Awake() {
        aiController = transform.parent.GetComponent<AIController>();
    }

    private void OnTriggerEnter(Collider other) {
        aiController.AttackPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        aiController.StopAttackPlayer(other);
    }
}
