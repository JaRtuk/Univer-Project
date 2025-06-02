using UnityEngine;
using UnityEngine.XR;

public class PlayerWeaponDamager : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float damage = 30f;
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private Collider weaponCollider;


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
        Debug.Log($"Collision with: {other.name}");
        // if (!isAttacking) return;

        if (other.CompareTag(enemyTag))
        {
            Damageable enemyDamageable = other.GetComponent<Damageable>();
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damage);
                DisableDamage();
                Invoke("EnableDamage", 1f);

                // VibrateController();
                // Debug.Log($"Игрок нанес урон: {damage}");
            }
        }
    }
}