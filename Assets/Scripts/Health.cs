using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    private GameObject healthBar;
    private Image healthImage;
    public GameObject healthPrefab;
    public Transform holder;
    public new Camera camera;
    public Vector3 offset;

    private void Awake() {
        healthBar = Instantiate(healthPrefab);
        healthBar.transform.SetParent(holder);
        healthImage = healthBar.GetComponent<Image>();
    }

    private void FixedUpdate() {
        healthBar.transform.position = camera.WorldToScreenPoint(transform.position + offset);
    }

    public void OnDamage(int amount) {
         curHealth = curHealth - amount;
         SetHealthBar();
    }
    
    public void SetHealthBar() {
        float fillPercentage = (float)curHealth / maxHealth;
        healthImage.fillAmount = fillPercentage;
    }
}   
