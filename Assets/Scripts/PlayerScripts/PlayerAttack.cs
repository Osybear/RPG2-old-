using UnityEngine;

[RequireComponent(typeof(NearestUnit))]
public class PlayerAttack : MonoBehaviour 
{
    private NearestUnit nearestUnit;
    public int damage;
    
    private void Awake() {
        nearestUnit = GetComponent<NearestUnit>();    
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            GameObject unit = nearestUnit.Nearest();

            if(unit == null)
               return; 
            
            Damageable damageable = unit.GetComponent<Damageable>();
            damageable.Damage(damage);
        }    
    }
}