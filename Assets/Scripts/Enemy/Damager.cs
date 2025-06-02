using UnityEngine;

public class EnemyWeaponDamager : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Collider weaponCollider;

    private AttakState attackState;

    private void Start()
    {
        attackState = GetComponentInParent<AttakState>();
        weaponCollider.enabled = false;
    }

    public void EnableDamage()
    {
        weaponCollider.enabled = true;
    }

    public void DisableDamage()
    {
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!weaponCollider.enabled) return;

        if (other.CompareTag(playerTag))
        {
            Damageable playerDamageable = other.GetComponent<Damageable>();
            if (playerDamageable != null)
            {
                playerDamageable.TakeDamage(damage);
                DisableDamage();
                Invoke("EnableDamage", 1.5f);
                // Debug.Log($"Противник нанес урон: {damage}");
            }
        }
    }
}