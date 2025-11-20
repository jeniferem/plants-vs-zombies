using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private float initialHealth =100f;
    private float currentHealh;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private UnityEvent onDie;
    public float CurrentHealth => currentHealh;
    public void InitializeHealth(float health)
    {
        initialHealth = health;
        currentHealh = initialHealth;
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        if (healthBar!= null)
        {
            healthBar.value = currentHealh / initialHealth;
        }
    }
    public void TakeDamage(float damage)
    {
        if (currentHealh <=0) return;
        currentHealh -= damage;
        currentHealh = Mathf.Clamp(currentHealh, 0, initialHealth);
        UpdateHealthBar();
        if (currentHealh <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        onDie?.Invoke();
    }
}
    
