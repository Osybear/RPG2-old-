using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    instatiate healthbars for components
    and manage them during runtime
*/
public class HealthBarInstantiate : MonoBehaviour
{   
    public HealthRuntimeSet healthRuntimeSet;
    public GameObject healthBarPrefab;
    public Transform healthBarParent;

    private void Start() {
        foreach (Health health in healthRuntimeSet.items) {
            GameObject healthBar = Instantiate(healthBarPrefab);
            healthBar.transform.SetParent(healthBarParent, false);

            HealthBarFollow healthbarFollow = healthBar.GetComponent<HealthBarFollow>();
            healthbarFollow.target = health.transform;
        }
    }

    public void HealtSetCheck() {
        
    }
}   
