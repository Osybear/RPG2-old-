using UnityEngine;
using UnityEngine.AI;

/*
    and hold data for other systems/logic
 */
public class AIController : MonoBehaviour
{   
    [HideInInspector] public NavMeshAgent agent;
    public Collider aggroPlayer;
    public float attackSpeed;
    public int damage;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();    
    }
}
