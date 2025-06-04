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

    public void Heal(int health)
    {
        if (currentHealth + health > 100)
        {
            currentHealth = currentHealth + health - (currentHealth + health - 100);
        }
        else
        {
            currentHealth += health;
        }

        if (healthSphere != null)
        {
            sphereScale = 2f * ((currentHealth / maxHealth));

            healthSphere.transform.localScale = new Vector3(sphereScale, sphereScale, 0.1f);
        }
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
            
        }
        else if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}