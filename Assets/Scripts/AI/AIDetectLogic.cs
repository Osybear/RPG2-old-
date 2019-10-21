using UnityEngine;

public class AIDetectLogic : MonoBehaviour 
{
    private AIController controller;
    
    private void Awake() {
        controller = GetComponent<AIController>();
    }

    public void AggroPlayer(Collider other) {
        if(controller.aggroPlayer == null) 
            controller.aggroPlayer = other;
    }

    public void DeAggroPlayer(Collider other) {
        if(other == controller.aggroPlayer)
            controller.aggroPlayer = null;
    }

    public void SetAgentDestination(Collider other) {
        if(controller.aggroPlayer != null && other == controller.aggroPlayer) {
            controller.agent.SetDestination(controller.aggroPlayer.transform.position);
        }
    }
}