using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour 
{
    private Health health;
 
    private void Awake() {
        health = GetComponent<Health>();
    }

    public void Damage(int amount) {
        health.curHealth = health.curHealth - amount;
    }
}