using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Transform healthBar;
    private Image healthImage;
    public new Camera camera;
    public RectTransform healthBarParent;
    public GameObject healthBarPrefab;
    public float curHealth;
    public float maxHealth;
    public Vector3 healtBarOffset;

    private void Awake() {
        healthBar = Instantiate(healthBarPrefab).transform;
        healthBar.SetParent(healthBarParent);
        healthImage = healthBar.GetChild(1).GetComponent<Image>();
    }

    private void FixedUpdate() {
        healthBar.position = camera.WorldToScreenPoint(transform.position + healtBarOffset);
    }

    public void Damage(int amount) {
         curHealth = curHealth - amount;
         SetHealthBar();
    }

    public void Health(int amount) {
        curHealth = curHealth + amount;
        SetHealthBar();
    }

    public void SetHealthBar() {
        healthImage.fillAmount = curHealth / maxHealth;
    }
}
