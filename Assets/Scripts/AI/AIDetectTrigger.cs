using UnityEngine;

public class AIDetectTrigger : MonoBehaviour
{
    private AIController aiController;

    private void Awake() {
        aiController = transform.parent.GetComponent<AIController>();
    }

    private void OnTriggerEnter(Collider other) {
        aiController.AggroPlayer(other);
    }

    private void OnTriggerExit(Collider other) {
        aiController.DeAggroPlayer(other);
    }

    private void OnTriggerStay(Collider other) {
        aiController.SetAgentDestination(other);
    }
}
