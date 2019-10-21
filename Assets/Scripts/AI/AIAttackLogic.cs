using System.Collections;
using UnityEngine;

public class AIAttackLogic : MonoBehaviour 
{   
    private Coroutine attackRoutine;
    private AIController controller;
    
    private void Awake() {
        controller = GetComponent<AIController>();
    }

    public void AttackPlayer(Collider other) {
        if(other == controller.aggroPlayer) {
            attackRoutine = StartCoroutine(AttackPlayerOverTime());
        }
    }

    public void StopAttackPlayer(Collider other) {
        if(other == controller.aggroPlayer) {
            StopCoroutine(attackRoutine);
        }
    }

    public IEnumerator AttackPlayerOverTime() {
        while(true) {
            yield return new WaitForSeconds(controller.attackSpeed);

            Damageable damageable = controller.aggroPlayer.GetComponent<Damageable>();
            if(damageable != null) {
                damageable.Damage(controller.damage);
            }
        }
    }
}