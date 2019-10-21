using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    get notified when an object needs a health bar
    if it receives the object
    update the healthbar
    and set position
 */
public class UIHealthController : MonoBehaviour
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

    public void Damage(int amount) {
         curHealth = curHealth - amount;
         SetHealthBar();
    }
    
    public void SetHealthBar() {
        float fillPercentage = (float)curHealth / maxHealth;
        healthImage.fillAmount = fillPercentage;
    }

    /*
    this system should be lookin at object with health
    instead of having the object tell the ui about it
     */
}   
