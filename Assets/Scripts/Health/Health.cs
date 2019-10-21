using UnityEngine;
/*
    this script will hold health data
    and add itself to a list
 */
public class Health : MonoBehaviour
{   
    public HealthRuntimeSet healthRuntimeSet;
    public int maxHealth;
    public int curHealth;

    private void Awake() {
        healthRuntimeSet.Add(this);
    }

    private void OnDisable() {
        healthRuntimeSet.Remove(this);
    }
}   