using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damageable playerHealth = other.GetComponent<Damageable>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}
