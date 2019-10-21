using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{   
    private GameObject healthBar;
    public GameObject healthBarPrefab;
    private Image healthImage;
    public new Camera camera;
    public Transform holder;
    public Vector3 offset;

    private void Awake() {
        healthBar = Instantiate(healthBarPrefab);
        healthBar.transform.SetParent(holder);
        healthImage = healthBar.GetComponent<Image>();
    }

    private void FixedUpdate() {
        healthBar.transform.position = camera.WorldToScreenPoint(transform.position + offset);
    }

    public void SetHealthBar() {
        //float fillPercentage = (float)curHealth / maxHealth;
        //healthImage.fillAmount = fillPercentage;
    }

}   
