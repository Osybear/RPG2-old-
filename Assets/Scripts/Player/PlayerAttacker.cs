using System.Collections;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    public LayerMask overlapMask;
    public int damage;
    public float maxAttackAngle;
    public float attackRate;
    public bool canAttack = true;

    private void Update() {
        if(Input.GetMouseButton(0) && canAttack) {
            AttackNearbyUnit();
            StartCoroutine(AttackBuffer());
        }
    }

    public void AttackNearbyUnit() {
        GameObject unit = GetNearestEnemy();
s
        if(unit == null)
            return; 
        
        
        HealthController health = unit.GetComponent<HealthController>();
        health.Damage(damage);

        Debug.DrawLine(transform.position, unit.transform.position, Color.red, 1f);
    }

    public GameObject GetNearestEnemy() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5, overlapMask);
        float smallestAngle = float.MaxValue;
        GameObject tempObj = null;

        foreach(Collider col in hitColliders){
            if(col.gameObject == this.gameObject)
                continue;
                
            Vector3 targetDir = col.transform.position - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);

            if(angle < smallestAngle) {
                tempObj = col.gameObject;
                smallestAngle = angle;
            }
        }
    
        if(smallestAngle < maxAttackAngle)
            return tempObj;
        return null;
    }  

    public IEnumerator AttackBuffer() {
        canAttack = false;
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
    }
}