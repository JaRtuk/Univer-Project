using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private GameObject healthSphere;
    private float sphereScale = 2f;

    [Header("События")]
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath;


    public float GetHeelth()
    {
        return currentHealth;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        if (healthSphere != null)
        {
            sphereScale = 2f * ((currentHealth / maxHealth));

            healthSphere.transform.localScale = new Vector3(sphereScale, sphereScale, 0.1f);
        }

        OnDamaged.Invoke();
        Debug.Log($"{gameObject.name} получил {damage} урона. Здоровье: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath.Invoke();
        
        if (gameObject.CompareTag("Enemy"))
        {
            // Логика смерти противника
            // Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}